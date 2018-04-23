using DevExpress.Mvvm;
using DevExpress.Mvvm.DataAnnotations;
using System;

namespace DXSample {
    public class ViewModel : ViewModelBase {
        private Customer Customer { get; set; }
        private bool IsReviewMode { get; set; }
        public MetadataExtendedSource Source {
            get { return GetProperty(() => Source); }
            set { SetProperty(() => Source, value); }
        }

        public ViewModel() {
            Customer = new Customer() {
                FirstName = "Anita",
                LastName = "Benson",
                BirthDate = new DateTime(1985, 3, 18),
                Phone = "(713) 863 813",
                Email = "@gmail.com",
            };
            Source = new MetadataExtendedSource(Customer, MetadataLocator.Create().AddMetadata(typeof(Customer), typeof(ReviewMetadata)));
            IsReviewMode = true;
        }
        [Command]
        public void ChangeSource() {
            if (IsReviewMode) {
                Source = new MetadataExtendedSource(Customer, MetadataLocator.Create().AddMetadata(typeof(Customer), typeof(Metadata)));
                IsReviewMode = false;
            } else {
                Source = new MetadataExtendedSource(Customer, MetadataLocator.Create().AddMetadata(typeof(Customer), typeof(ReviewMetadata)));
                IsReviewMode = true;
            }
        }
    }

    public class Customer {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string FullName { get { return string.Format("{0} {1}", FirstName, LastName); } }
        public string Phone { get; set; }
        public string Email { get; set; }
        public DateTime BirthDate { get; set; }
    }
}
