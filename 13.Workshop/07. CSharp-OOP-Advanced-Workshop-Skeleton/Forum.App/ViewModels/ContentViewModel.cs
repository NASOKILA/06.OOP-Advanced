namespace Forum.App.ViewModels
{
    using System.Collections.Generic;
    using System.Linq;
    

    public abstract class ContentViewModel
    {
        private const int lineLength = 37;

        //tuk durjim logika za post view modl i  reply view model

        //rzdelq string na redove v masiva

        //moje da se polzvae i ot decata mu
        protected ContentViewModel(string text)
        {
            this.Content = GetLines(text);
        }


        public string[] Content { get; }

        //razdelq stringa na redove na vseki 37mi sinvol
        private string[] GetLines(string text)
        {

            char[] contentChars = text.ToCharArray();

            ICollection<string> lines = new List<string>();

            for (int i = 0; i < contentChars.Length; i+= lineLength) //uvelichavame 'i' s 37 vseki put
            {
                char[] lineChars = contentChars.Skip(i).Take(lineLength).ToArray();
                string line = string.Join("", lineChars);
                lines.Add(line);
            }


            return lines.ToArray();
        }


    }
}
