using System;
using System.IO;

namespace GameEngine {
    class Run {
        static void Main(string[] args) {
            Source.GameInstance engine = new Source.GameInstance("Test");
            engine.Run();
        }
    }
}