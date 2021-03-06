﻿namespace Logger.Models
{
    using Contracts;
    using System;
    using System.Globalization;
    
    public class XmlLayout : ILayout
    {
        const string DateFormat = "HH:mm:ss dd-MMM-yyyy";

        private string layout =
            "<log>" + Environment.NewLine +
                "\t<date>{0}</date>" + Environment.NewLine +
                "\t<level>{1}</level>" + Environment.NewLine +
                "\t<message>{2}</message>" + Environment.NewLine +
            "</log>";

        public string FormatError(IError error)
        {
            string dateString = error.DateTime.ToString(DateFormat, CultureInfo.InvariantCulture);
                
            string formattedError = string.Format(this.layout, dateString, error.Level.ToString(), error.Message);
            
            return formattedError;
        }
    }
}