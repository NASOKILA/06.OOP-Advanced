namespace Logger.Models.Factories
{
    using Contracts;
    using System;

    public class LayoutFactory
    {
        public LayoutFactory()
        {

        }

        //vrushta suzdaden ot nas layout
        public ILayout CreateLayout(string layoutType)
        {   
            ILayout layout = null;

            switch (layoutType)
            {
                case "SimpleLayout":
                    layout = new SimpleLayout();
                    break;

                case "XmlLayout":
                    layout = new XmlLayout();
                    break;

                default:
                    throw new ArgumentException("Invalid Layout Type!");
            }

            return layout;
        }

    }
}
