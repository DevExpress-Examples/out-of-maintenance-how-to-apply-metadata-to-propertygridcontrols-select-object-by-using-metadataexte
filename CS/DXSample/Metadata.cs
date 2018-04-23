using DevExpress.Mvvm.DataAnnotations;
using System;

namespace DXSample {
    public class Metadata : IMetadataProvider<Customer> {
        void IMetadataProvider<Customer>.BuildMetadata(MetadataBuilder<Customer> builder) {
            builder
                .Property(x => x.ID)
                    .ReadOnly()
                .EndProperty()
                .Property(x => x.FirstName)
                    .DisplayName("First Name")
                    .MaxLength(40)
                .EndProperty()
                .Property(x => x.LastName)
                    .DisplayName("Last Name")
                    .MaxLength(40)
                .EndProperty()
                .Property(x => x.FullName)
                    .Hidden()
                .EndProperty()
                .Property(x => x.Phone)
                    .DisplayName("Phone number")
                    .PhoneNumberDataType()
                .EndProperty()
                .Property(x => x.Email)
                    .DisplayName("Email")
                    .EmailAddressDataType()
                .EndProperty()
                .Property(x => x.BirthDate)
                    .DisplayName("Birth date")
                    .DateTimeDataType()
                .EndProperty();
            builder
                .Group("Personal")
                    .ContainsProperty(x => x.ID)
                    .ContainsProperty(x => x.BirthDate)
                .EndGroup()
                .Group("Name")
                    .ContainsProperty(x => x.FirstName)
                    .ContainsProperty(x => x.LastName)
                .EndGroup()
                .Group("Contact")
                    .ContainsProperty(x => x.Phone)
                    .ContainsProperty(x => x.Email)
                .EndGroup();
        }
    }

    public class ReviewMetadata : IMetadataProvider<Customer> {
        void IMetadataProvider<Customer>.BuildMetadata(MetadataBuilder<Customer> builder) {
            builder
                .Property(x => x.ID)
                    .Hidden()
                .EndProperty()
                .Property(x => x.FirstName)
                    .Hidden()
                .EndProperty()
                .Property(x => x.LastName)
                    .Hidden()
                .EndProperty()
                .Property(x => x.FullName)
                    .DisplayName("Full Name")
                    .ReadOnly()
                .EndProperty()
                .Property(x => x.Phone)
                    .DisplayName("Phone number")
                    .PhoneNumberDataType()
                .EndProperty()
                .Property(x => x.Email)
                    .DisplayName("Email")
                    .EmailAddressDataType()
                .EndProperty()
                .Property(x => x.BirthDate)
                    .Hidden()
                .EndProperty();
            builder
                .Group("Name")
                    .ContainsProperty(x => x.FullName)
                .EndGroup()
                .Group("Contact")
                    .ContainsProperty(x => x.Phone)
                    .ContainsProperty(x => x.Email)
                .EndGroup();
        }
    }
}
