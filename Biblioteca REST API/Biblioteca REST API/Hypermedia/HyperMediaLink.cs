﻿using System.Text;

namespace Biblioteca_REST_API.Hypermedia
{
    public class HyperMediaLink
    {
        public string Rel {  get; set; }
        private string href {  get; set; }
        public string Href {
            get
            {
                object _lock = new object();
                lock (_lock)
                {
                    StringBuilder stringBuilder = new StringBuilder(href);
                    return stringBuilder.Replace("%2F", "/").ToString();
                }
            }
            set { href = value;} 
        }
        public string Type {  get; set; }
        public string Action {  get; set; }
    }
}
