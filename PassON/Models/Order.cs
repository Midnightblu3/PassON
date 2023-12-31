﻿using Microsoft.AspNetCore.Mvc.ModelBinding;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace PassON.Models
{
    public class Order
    {
        [BindNever]
        public int Id { get; set; }
        public List<OrderDetail> OrderDetails { get; set; } = new List<OrderDetail>();

        [Required(ErrorMessage = "Please enter your first Name")]
        [Display(Name ="First Name")]
        [StringLength(50)]
        public string FirstName { get; set; } =string.Empty;

        [Required(ErrorMessage = "Please enter your last Name")]
        [Display(Name = "Last Name")]
        [StringLength(50)]
        public string LastName { get; set; } =string.Empty;

        [Required(ErrorMessage = "Please enter your address")]
        [Display(Name = "Address line 1")]
        [StringLength(100)]
        public string AddressLine1 { get; set; } =string.Empty;

        
        [Display(Name = "Address line 2")]
        public string AddressLine2 { get; set; } =string.Empty;

        [Required(ErrorMessage = "Please enter your Zip code")]
        [Display(Name = "Zip code")]
        [StringLength(10,MinimumLength =4)]
        public string ZipCode { get; set; } =string.Empty;

        [Required(ErrorMessage ="Please enter your city")]
        [StringLength(50)]
        public string City { get; set; } =string.Empty;

        [StringLength(50)]
        public string? State { get; set; }

        [Required(ErrorMessage= "Please enter your country")]
        [StringLength (50)]
        public string Country { get; set; } =string.Empty;

        [Required(ErrorMessage="Please enter your phone number")]
        [StringLength(25)]
        [DataType(DataType.PhoneNumber)]
        [Display(Name =" Phone number")]
        public string PhoneNumber { get; set; } =string.Empty;


        [Required]
        [StringLength(50)]
        [DataType(DataType.EmailAddress)]
        [RegularExpression(@"(?:[a-z0-9!#$%&'*+/=?^_`{|}~-]+(?:\.[a-z0-9!#$%&'*+/=?^_`{|}~-]+)*|""(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21\x23-\x5b\x5d-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])*"")@(?:(?:[a-z0-9](?:[a-z0-9-]*[a-z0-9])?\.)+[a-z0-9](?:[a-z0-9-]*[a-z0-9])?|\[(?:(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?)\.){3}(?:25[0-5]|2[0-4][0-9]|[01]?[0-9][0-9]?|[a-z0-9-]*[a-z0-9]:(?:[\x01-\x08\x0b\x0c\x0e-\x1f\x21-\x5a\x53-\x7f]|\\[\x01-\x09\x0b\x0c\x0e-\x7f])+)\])",
            ErrorMessage = "The email address is not entered in a correct format")]
        public string Email { set; get; } =string.Empty;

        [BindNever]
        public decimal OrderTotal { get; set; } =decimal.Zero;

        [BindNever]
        public DateTime OrderPlace { get; set; }


    }
}
