//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace WebApi.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    public partial class AddressBook
    {
        [Required(ErrorMessage = "This field is required")]
        public int Id { get; set; }
        [Required(ErrorMessage ="This field is required")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Surname { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public int Age { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public System.DateTime Birthday { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Tel { get; set; }
        [Required(ErrorMessage = "This field is required")]
        public string Address { get; set; }
    }
}