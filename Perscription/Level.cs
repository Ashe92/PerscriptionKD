//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Perscription
{
    using System;
    using System.Collections.Generic;
    
    public partial class Level
    {
        public int IdLevel { get; set; }
        public string LevelName { get; set; }
        public string Description { get; set; }
        public int MedicineBL7 { get; set; }
    
        public virtual Medicine Medicine { get; set; }
    }
}