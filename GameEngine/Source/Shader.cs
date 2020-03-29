using System;
using System.IO;
using System.Text;
using OpenTK.Graphics.OpenGL;

namespace GameEngine.Source {
    public  class Shader {
        int handle;
        private bool disposedValue = false;
        public Shader(string vertex_path, string fragment_path) {
            var vertex_shader = GL.CreateShader(ShaderType.VertexShader);
            GL.ShaderSource(vertex_shader,
            File.ReadAllText(vertex_path));
            GL.CompileShader(vertex_shader);

            var fragment_shader = GL.CreateShader(ShaderType.FragmentShader);
            GL.ShaderSource(fragment_shader,
            File.ReadAllText(fragment_path));
            GL.CompileShader(fragment_shader);

            handle = GL.CreateProgram();
            GL.AttachShader(handle, vertex_shader);
            GL.AttachShader(handle, fragment_shader);
            GL.LinkProgram(handle);

            GL.DetachShader(handle, vertex_shader);
            GL.DetachShader(handle, fragment_shader);
            GL.DeleteShader(vertex_shader);
            GL.DeleteShader(fragment_shader);
        }
        public void Use() {
            GL.UseProgram(handle);
        }
        protected virtual void Dispose(bool disposing) {
            if (!disposedValue) {
                GL.DeleteProgram(handle);

                disposedValue = true;
            }
        }
        ~Shader() {
            GL.DeleteProgram(handle);
        }
        public void Dispose() {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
