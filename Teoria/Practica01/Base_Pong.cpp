
//Base_Pong.cpp : A bouncing ball 

//#include <windows.h> //the windows include file, required by all windows applications
#include <GL/glut.h> //the glut file for windows operations
                     // it also includes gl.h and glu.h for the openGL library calls
#include <math.h>
//MOdificación-------
#include <iostream>
using namespace std;
//-------------------
#define PI 3.1415926535898 

double xpos, ypos, ydir, xdir;         // x and y position for house to be drawn
double sx, sy, squash;          // xy scale factors
double rot, rdir;             // rotation
double ball_speed;
//Modificación---------------------
int score1 = 0;
int score2 = 0;
//---------------------------------
//Modificación--------------------------
double paddle1_y, paddle2_y;

const double paddle_width = 5.0;
const double paddle_height = 30.0;
//--------------------------------------

GLfloat T1[16] = {1.,0.,0.,0.,\
                  0.,1.,0.,0.,\
                  0.,0.,1.,0.,\
                  0.,0.,0.,1.};
GLfloat S[16] = {1.,0.,0.,0.,\
                 0.,1.,0.,0.,\
                 0.,0.,1.,0.,\
                 0.,0.,0.,1.};
GLfloat T[16] = {1.,0.,0.,0.,\
                 0., 1., 0., 0.,\
                 0.,0.,1.,0.,\
                 0.,0.,0.,1.};



#define PI 3.1415926535898 
GLint circle_points = 100; 
void MyCircle2f(GLfloat centerx, GLfloat centery, GLfloat radius){
  GLint i;
  GLdouble angle;
  glBegin(GL_POLYGON); 
  for (i = 0; i < circle_points; i++) {    
    angle = 2*PI*i/circle_points; 
    glVertex2f(centerx+radius*cos(angle), centery+radius*sin(angle)); 
  } 
  glEnd();
}

GLfloat RadiusOfBall = 15.;
// Draw the ball, centered at the origin
void draw_ball() {
  //modificación:color blanco
  glColor3f(1.0, 1.0, 1.0);
  MyCircle2f(0.,0.,RadiusOfBall);
  
}

//Modificación
void draw_paddle(double x, double y)
{
    glBegin(GL_QUADS);

    glVertex2f(x, y);
    glVertex2f(x + paddle_width, y);
    glVertex2f(x + paddle_width, y + paddle_height);
    glVertex2f(x, y + paddle_height);

    glEnd();
}

//Modificación
void keyboard(unsigned char key, int x, int y)
{
    if (key == 'w' || key == 'W') {
        paddle1_y += 5.0;

        if (paddle1_y + paddle_height > 120.0)
            paddle1_y = 120.0 - paddle_height;
    }

    if (key == 's' || key == 'S') {
        paddle1_y -= 5.0;

        if (paddle1_y < 0.0)
            paddle1_y = 0.0;
    }

    glutPostRedisplay();
}

//Modificación
void special_keyboard(int key, int x, int y)
{
    if (key == GLUT_KEY_UP) {
        paddle2_y += 5.0;

        if (paddle2_y + paddle_height > 120.0)
            paddle2_y = 120.0 - paddle_height;
    }

    if (key == GLUT_KEY_DOWN) {
        paddle2_y -= 5.0;

        if (paddle2_y < 0.0)
            paddle2_y = 0.0;
    }

    glutPostRedisplay();
}



void Display(void)
{
  // swap the buffers
  glutSwapBuffers(); 

  //clear all pixels with the specified clear color
  glClear(GL_COLOR_BUFFER_BIT);
  // 160 is max X value in our world

 	
	// Shape has hit the ground! Stop moving and start squashing down and then back up 
	if (ypos == RadiusOfBall && ydir == -1  ) { 
		sy = sy*squash ; 
		
		if (sy < 0.8)
			// reached maximum suqash, now unsquash back up 
			squash = 1.1;
		else if (sy > 1.) {
			// reset squash parameters and bounce ball back upwards
			sy = 1.;
			squash = 0.9;
			ydir = 1;
		}
		sx = 1./sy;

        // 120 is max Y value in our world
	    
	} else {
        // set Y position to increment 1.5 times the direction of the bounce
        ypos += ydir*ball_speed;
        //Modicación: La pelota ahora se mueve horizontalmente
        xpos += xdir*ball_speed;
//MODIFICACIÓN-----------------------------------------------------------
        // Colisión con la paleta izquierda
        if (xpos - RadiusOfBall <= 5.0 + paddle_width &&
            xpos - RadiusOfBall >= 5.0 &&
            ypos + RadiusOfBall >= paddle1_y &&
            ypos - RadiusOfBall <= paddle1_y + paddle_height)
        {
            xdir = 1;
        }

        // Colisión con la paleta derecha
        if (xpos + RadiusOfBall >= 150.0 &&
            xpos + RadiusOfBall <= 150.0 + paddle_width &&
            ypos + RadiusOfBall >= paddle2_y &&
            ypos - RadiusOfBall <= paddle2_y + paddle_height)
        {
            xdir = -1;
        }
//-----------------------------------------------------------------------

//----------------Modificación----------------------------------
        if (xpos < 0.0)
        {
            score2++;

            cout << "Jugador 1: " << score1
                 << " | Jugador 2: " << score2 << endl;

            xpos = 80.0;
            ypos = 60.0;

            xdir = -1;
            ydir = 1;
        }

        // Punto-jugador 1
        if (xpos > 160.0)
        {
            score1++;

            cout << "Jugador 1: " << score1
                 << " | Jugador 2: " << score2 << endl;

            xpos = 80.0;
            ypos = 60.0;

            xdir = 1;
            ydir = 1;
        }
// ---------------------------------------------------------


	    // If ball touches the top, change direction of ball downwards
  	    if (ypos == 120-RadiusOfBall){
    	    ydir = -1;
        }
	    // If ball touches the bottom, change direction of ball upwards
        else if (ypos < RadiusOfBall)
		    ydir = 1;




	}

/*  //reset transformation state 
  glLoadIdentity();
  
  // apply translation
  glTranslatef(xpos,ypos, 0.);

  // Translate ball back to center
  glTranslatef(0.,-RadiusOfBall, 0.);
  // Scale the ball about its bottom
  glScalef(sx,sy, 1.);
  // Translate ball up so bottom is at the origin
  glTranslatef(0.,RadiusOfBall, 0.);
  // draw the ball
  draw_ball();
*/
 
  //Translate the bouncing ball to its new position
  T[12]= xpos;
  T[13] = ypos;
  glLoadMatrixf(T);

  T1[13] = -RadiusOfBall;
  // Translate ball back to center
  glMultMatrixf(T1);
  S[0] = sx;
  S[5] = sy;
  // Scale the ball about its bottom
  glMultMatrixf(S);
  
  T1[13] = RadiusOfBall;
  // Translate ball up so bottom is at the origin

  glMultMatrixf(T1);
  
  draw_ball();
  //Modificación
  glLoadIdentity();

  //Modificación: color verde
  glColor3f(0.0, 1.0, 0.0);

  draw_paddle(5.0, paddle1_y);
  draw_paddle(150.0, paddle2_y);

  glutPostRedisplay(); 

  

}


void reshape (int w, int h)
{
   // on reshape and on startup, keep the viewport to be the entire size of the window
   glViewport (0, 0, (GLsizei) w, (GLsizei) h);
   glMatrixMode (GL_PROJECTION);
   glLoadIdentity ();

   // keep our logical coordinate system constant
   gluOrtho2D(0.0, 160.0, 0.0, 120.0);
   glMatrixMode(GL_MODELVIEW);
   glLoadIdentity ();

}


void init(void){
  //Modificación: color negro
  glClearColor(0.0, 0.0, 0.0, 1.0);  
  // initial position set to 0,0
  xpos = 80; ypos = RadiusOfBall; xdir = 1; ydir = 1;
  sx = 1.; sy = 1.; squash = 0.9;
  rot = 0;
  ball_speed = 1.5;
  //Modificación
  paddle1_y = 45.0;
  paddle2_y = 45.0;

}


int main(int argc, char* argv[])
{

  glutInit( & argc, argv );
  glutInitDisplayMode(GLUT_DOUBLE | GLUT_RGB);
  glutInitWindowSize (320, 240);   
  glutCreateWindow("Bouncing Ball");
  init();
  glutDisplayFunc(Display);
  glutReshapeFunc(reshape);
  //Modificación-------------------------
  glutKeyboardFunc(keyboard);
  glutSpecialFunc(special_keyboard);
  //'------------------------------------
  glutMainLoop();

  return 1;
}