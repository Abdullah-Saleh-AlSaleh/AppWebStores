using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace AppWeb.Models
{
    //Admin
    public class Store
    {
        public string Id { get; set; }

        [Display(Name = "اسم المنتج")]
        public string ProducetName { get; set; }
        [Display(Name = "تفاصيل المنتج")]
        public string ProducetDetails { get; set; }
        [Display(Name = "سعر")]
        public string Price { get; set; }
        [Display(Name = "الصورة امام ")]
        public string image1 { get; set; }
        [Display(Name = "الصورة الخلف")]
        public string image2 { get; set; }
        [Display(Name = "Email")]
        public string image3 { get; set; }
        [Display(Name = "Email")]
        public string image4 { get; set; }
        public string image5 { get; set; }
        [Display(Name = "تاريخ إضافة المنتج")]
        public DateTime ProducetAddDateTime { get; set; }
        public string UserId { get; set; }

    }




    //User
    public class AddStore
    {

        public string Id { get; set; }
        public string StoreId { get; set; }
        [Display(Name = "اسم المنتج")]
        public string ProducetName { get; set; }
        [Display(Name = "تفاصيل المنتج")]
        public string ProducetDetails { get; set; }
        [Display(Name = "سعر")]
        public string Price { get; set; }

        [Display(Name = "كمية")]
        public int Quantity { get; set; }
        public bool TrueuOrFalse { get; set; }

        [Display(Name = "تاريخ إضافة المنتج")]
        public DateTime ProducetAddDateTime { get; set; }
        //Get Locations
        [Display(Name = "حي")]
        public string District { get; set; }
        [Display(Name = "المدينة")]
        public string City { get; set; }
        [Display(Name = "شارع")]
        public string Street { get; set; }
        //edit Store
        public bool StoreTrueuOrFalse { get; set; }
        [Display(Name = "الحالة الطلب")]
        public string TextToHome { get; set; }

        public string UserId { get; set; }

    }

    public class Comment{
        public string Id { get; set; }
        [Display(Name = "رقم المنتج")]
        public string StoreId { get; set; }
        [Display(Name = "اسم المنتج")]
        public string ProducetName { get; set; }
  
        [Display(Name = "الاسم الكامل")]
        public string FullName { get; set; }
        [Display(Name = "كتابة تعليق")]
        public string Text { get; set; }
        [Display(Name = "تقييم")]
        public string Comme { get; set; }
        [Display(Name = "تاريخ إضافة")]
        public DateTime DateTime { get; set; }
        public string UserId { get; set; }

    }

    public static class NumberId
    {
        public static int Id(int id)
        {
            return id;
        }

    }
}