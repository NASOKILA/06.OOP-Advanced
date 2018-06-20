using System;

namespace P02.Graphic_Editor
{
    class Program
    {
        static void Main()
        {
            GraphicEditor graphicEditor = new GraphicEditor();

            IShape shapeC = new Circle();
            IShape shapeR = new Rectangle();
            IShape shapeS = new Square();
            

            graphicEditor.DrawShape(shapeS);

        }
    }
}
