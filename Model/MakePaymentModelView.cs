using System.Text.RegularExpressions;

namespace pocPagSeguro.Model
{
    public class MakePaymentModelView
    {
        public string EmailPagSeguro { get; set; }

        public string TokenPagSeguro { get; set; }

        public string Email { get; set; }

        public string Name { get; set; }

        public string Phone { get; set; }

        public string CardToken { get; set; }

        public string CardholderName { get; set; }

        public decimal Value { get; set; }

        public string HashCLient { get; set; }

        public BillingAddress BillingAddress { get; set; }

        public string CPF => "00933317972";

        public string BirthDate => "19/09/1978";

        public string AreaCode => Phone.Substring(0, 2);

        public string NumberPhone => Phone.Substring(2);

    }

    public class BillingAddress
    {
        public string Address { get; set; }

        public string City { get; set; }

        public string Country { get; set; }

        public string Neighbour { get; set; }

        public string Type { get; set; }

        public string PostalCode { get; set; }

        public string NameBilling { get; set; }

        public string StateCode { get; set; }

        public string AddressStreet => Address.Replace(Number, "");
        public string Number => Regex.Match(Address, "[0-9]*$").Value;
    }
}
