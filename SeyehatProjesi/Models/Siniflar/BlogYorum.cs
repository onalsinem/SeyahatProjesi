//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Web;

//namespace SeyehatProjesi.Models.Siniflar
//{
//    public class BlogYorum
//    {
//        public IEnumerable<Blog> Deger1 { get; set; }

//        public IEnumerable<Yorumlar> Deger2 { get; set; }

//        public IEnumerable<Blog> Deger3 { get; set; }


//    }
//}

using System;
using System.Linq;
using System.Web;
using SeyehatProjesi.Models.Siniflar;
using System.Collections.Generic;

namespace SeyehatProjesi.Models.Siniflar { 
    public class BlogYorum{
    public IEnumerable<Blog> Deger1 { get; set; } = new List<Blog>();
    public IEnumerable<Yorumlar> Deger2 { get; set; } = new List<Yorumlar>();
    public IEnumerable<Blog> Deger3 { get; set; } = new List<Blog>();
    }
}
