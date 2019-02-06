using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Metadata.W3cXsd2001;
using System.Text;
using System.Threading.Tasks;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace Open_tk_triangle
{
    public class Graph
    {
        private double angle = 0;
        GameWindow window;

        public Graph(GameWindow window)
        {
            this.window = window;
            Start();
        }

        void Start()
        {
            window.Load += Loaded;
            window.RenderFrame += Renderf;
            window.Resize += Resize;
            window.Run();

        }

        void Renderf(object o, EventArgs e)
        {
            GL.LoadIdentity();
            GL.Clear(ClearBufferMask.ColorBufferBit);
            GL.Rotate(angle, 0, 0, 1);
            GL.Begin(BeginMode.Quads);

            GL.Color3(1.0, 0.0, 0.0);
            GL.Vertex2(30, 30);
            GL.Color3(1.0, 0.0, 0.0);
            GL.Vertex2(-30, 30);
            GL.Color3(1.0, 0.0, 0.0);
            GL.Vertex2(-30, -30);
            GL.Vertex2(30, -30);
            GL.Vertex2(30, -60);

            GL.End();
            window.SwapBuffers();
            angle += 1;
            if (angle > 360)
                angle -= 360;
        }
        
        void Loaded(object o, EventArgs e)
        {
            GL.ClearColor(0, 0, 0, 0);
        }

        void Resize(object o, EventArgs e)
        {
            GL.Viewport(0, 0, window.Width, window.Height);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-50, 50, -50, 50, -1, 1);
            GL.MatrixMode(MatrixMode.Modelview);
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
         var window = new GameWindow(500, 500);
            var graph = new Graph(window);
        }
    }
}
