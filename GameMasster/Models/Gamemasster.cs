using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel.DataAnnotations;
using System.Threading.Tasks;

namespace GameMasster.Models
{
    public class Gamemasster
    {
        [Display(Name ="mã game")]
        public int Id { get; set; }
        [Display(Name = "tên game")]
        public string Title { get; set; }
        [Display(Name = "ngày phát hành")]
        [DataType(DataType.Date)]
        public DateTime ReleaseDate { get; set; }
        [Display(Name = "nhà sản xuất")]
        public string Genre { get; set; }
        [Display(Name = "giá tiền")]
        public decimal Price { get; set; }
        [Display(Name ="đánh giá")]
        public string Rating { get; set; }
        [Display(Name ="link tai game")]
        public string Link { get; set; }

    }
}
