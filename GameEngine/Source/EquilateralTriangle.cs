using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using OpenTK.Graphics.OpenGL;

namespace GameEngine.Source {
    public class EquilateralTriangle {
        double[] vertices;
        private int VBO;
        private int VAO;
        public EquilateralTriangle(double[] position, double[] scale) {
            vertices = new double[] {
                 0.0f,  0.5f, 0.0f, // Vertex 1 (X, Y)
                 0.5f,  0.0f, 0.0f, // Vertex 2 (X, Y)
                 0.0f,  0.0f, 0.0f  // Vertex 3 (X, Y)
            };
            VBO = GL.GenBuffer();
            VAO = GL.GenVertexArray();
            GL.BindVertexArray(VAO);
            GL.BindBuffer(BufferTarget.ArrayBuffer, VBO);
            GL.BufferData(BufferTarget.ArrayBuffer, vertices.Length * sizeof(float), vertices, BufferUsageHint.StaticDraw);
            GL.VertexAttribPointer(0, 3, VertexAttribPointerType.Double, false, 3 * sizeof(double), 0);
            GL.EnableVertexAttribArray(0);
        }
        public void Draw(Shader shader) {
            shader.Use();
            GL.BindVertexArray(VAO);
            GL.DrawArrays(PrimitiveType.Triangles, 0, 3);
        }
        public void Delete() {
            GL.BindBuffer(BufferTarget.ArrayBuffer, 0);
            GL.DeleteBuffer(VBO);
        }
        public double[] getVertices() {
            return vertices;
        }
        public int getVBO() {
            return VBO;
        }
    }
}