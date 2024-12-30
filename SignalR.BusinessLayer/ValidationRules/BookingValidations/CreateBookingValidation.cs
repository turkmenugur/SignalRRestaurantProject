using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using FluentValidation;
using SignalR.DtoLayer.BookingDto;

namespace SignalR.BusinessLayer.ValidationRules.BookingValidations
{
    public class CreateBookingValidation : AbstractValidator<CreateBookingDto>
    {
        public CreateBookingValidation()
        {
            RuleFor(x => x.Name).NotEmpty().WithMessage("İsim alanı boş geçilemez!");
            RuleFor(x => x.Phone).NotEmpty().WithMessage("Telefon alanı boş geçilemez!");
            RuleFor(x => x.Mail).NotEmpty().WithMessage("Mail alanı boş geçilemez");
            RuleFor(x => x.PersonCount).NotEmpty().WithMessage("Kişi sayısı alanı boş geçilemez!");
            RuleFor(x => x.Date).NotEmpty().WithMessage("Tarih alanı boş geçilemez!");
            
            RuleFor(x => x.Name).MinimumLength(5).WithMessage("İsim alanı en az 5 karakter olmalıdır!").MaximumLength(500).WithMessage("İsim alanı en fazla 500 karakter olmalıdır!");
            RuleFor(x => x.Description).MaximumLength(500).WithMessage("Açıklama alanı en fazla 500 karakter olmalıdır!");
            
            RuleFor(x => x.Mail).EmailAddress().WithMessage("Geçerli bir mail adresi giriniz!");
        }
    }
}
