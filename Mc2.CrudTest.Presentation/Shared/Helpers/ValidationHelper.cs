using PhoneNumbers;

namespace Mc2.CrudTest.Presentation.Shared.Helpers
{
    public static class ValidationHelper
    {
        public static bool BeValidPhoneNumber(this string inputPhoneNumber)
        {
            var phoneNumberUtil = PhoneNumberUtil.GetInstance();
            try
            {
                var phoneNumber = phoneNumberUtil.Parse(inputPhoneNumber, null);
                return phoneNumberUtil.IsValidNumber(phoneNumber);
            }
            catch (NumberParseException e)
            {
                // todo : log with serilog
                return false;
            }
        }
    }
}
