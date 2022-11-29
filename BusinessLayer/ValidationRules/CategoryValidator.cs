using EntityLayer.Concrete;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BusinessLayer.ValidationRules
{
    public class CategoryValidator : AbstractValidator<Category>
    {
        public CategoryValidator()        // Veri girişi için kuralları buraya yazıyoruz.
        {
            RuleFor(x => x.CategoryName).NotEmpty().WithMessage("Kategori Adını Boş Geçemezsiniz"); /*Boş geçememeleri için NotEmpty() kullanılıyor.*/
            RuleFor(x => x.CategoryDescription).NotEmpty().WithMessage("Açıklamayı Boş Geçemezsiniz."); /*Boş geçememeleri için NotEmpty() kullanılıyor.*/
            RuleFor(x => x.CategoryName).MinimumLength(3).WithMessage("Lütfen en az 3 karakter giriniz."); /* Girilebilecek en az karakteri belirlemek için MinimumLength(n) kullanılıyor.*/
            RuleFor(x => x.CategoryName).MaximumLength(20).WithMessage("Lütfen 20 karakterden fazla değer girişi yapmayın."); /* Girilebilecek en fazla karakteri belirlemek için MaximumLength(n) kullanılıyor.*/
        }
    }
}
