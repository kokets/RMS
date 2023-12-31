﻿using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;


//model to handle all the gifts database queries


namespace HSRC_RMS.Models
{

    public class JointSupervisionsRegister
    {
        [Key] // This attribute marks GiftId as the primary key
        public int SupervisionID { get; set; }


        [Required(ErrorMessage = "Opportunity Title is required")]
        public string? Budgetyears { get; set; }

        [Required(ErrorMessage = "Opportunity Funder is required")]
        public string? SuperVisor { get; set; }

        [Required(ErrorMessage = "Opportunity Program is required")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Opportunity Program is required")]
        public string? Institution { get; set; }

    

        [Required(ErrorMessage = "Opportunity Status is required")]
        public string? Status { get; set; }

        [Required(ErrorMessage = "Opportunity Url is required")]
        public DateTime? StartDate { get; set; }

        [Required(ErrorMessage = "Opportunity Url is required")]
        public DateTime? EndDate { get; set; }

        [Required(ErrorMessage = "Opportunity SubmissionDate is required")]
        public string? Document { get; set; }

    }


    public class JointSupervisionsDisplay
    {
        [Key] // This attribute marks GiftId as the primary key
        public int SupervisionID { get; set; }

        public string? Budgetyears { get; set; }


        [Required(ErrorMessage = "Opportunity Title is required")]
        public string? SuperVisor { get; set; }

        public string? Title { get; set; }

        public string? Institution { get; set; }


        public DateTime? StartDate { get; set; }

        public DateTime? EndDate { get; set; }

        public string? Status { get; set; }

        public string? Document { get; set; }


    }

    public class JointSupervisionsEditGet
    {

        public List<SelectListItem> UsersOptionAsync { get; set; } // New property
        public List<SelectListItem> TypeOptionsAsync { get; set; } // New property
        public List<SelectListItem> SupplierOptionsAsync { get; set; } // New property

        public JointSupervisionsRegister NewEditCapture { get; set; }
        public List<JointSupervisionsRegister> LicenseEditList { get; set; }


        public int SupervisionID { get; set; } // Add this property


        public JointSupervisionsEditGet()
        {

            UsersOptionAsync = new List<SelectListItem>(); // Initialize the list
            TypeOptionsAsync = new List<SelectListItem>(); // Initialize the list
            SupplierOptionsAsync = new List<SelectListItem>(); // Initialize the list
            NewEditCapture = new JointSupervisionsRegister();
            LicenseEditList = new List<JointSupervisionsRegister>();



        }
    }

}
