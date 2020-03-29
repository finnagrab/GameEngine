using System;
using System.IO;

using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;

namespace GameEngine.Source {
    class GameInstance : GameWindow {
        EquilateralTriangle triangle;
        GameEngine.Source.Shader shader;
        public GameInstance(string title) : base(640, 480, GraphicsMode.Default) {
            
        }
        protected override void OnUpdateFrame(FrameEventArgs e) {
            KeyboardState input = Keyboard.GetState();
            if ((input.IsKeyDown(Key.AltLeft) || input.IsKeyDown(Key.AltRight)) && input.IsKeyDown(Key.F4)) {
                Exit();
            }
            GL.Clear(ClearBufferMask.ColorBufferBit);

            triangle.Draw(shader);

            Context.SwapBuffers();
            base.OnUpdateFrame(e);
        }
        protected override void OnLoad(EventArgs e) {
            string solution = Path.GetFullPath(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "..\\..\\"));
            Console.WriteLine(solution);
            GL.ClearColor(0.0f, 0.0f, 0.0f, 1.0f);
            shader = new Shader(Path.Combine(solution, "Shader\\shader.vert"), Path.Combine(solution, "Shader\\shader.frag"));
            triangle = new GameEngine.Source.EquilateralTriangle(new double[3] { 0, 0, 0 }, new double[3] { 1, 1, 1 });
            base.OnLoad(e);
        }
        protected override void OnUnload(EventArgs e) {
            triangle.Delete();
            shader.Dispose();
            base.OnUnload(e);
        }
    }
}
