Imports DevExpress.Mvvm.DataAnnotations

Namespace DXSample

    Public Class Metadata
        Implements IMetadataProvider(Of Customer)

        Private Sub BuildMetadata(ByVal builder As MetadataBuilder(Of Customer)) Implements IMetadataProvider(Of Customer).BuildMetadata
            PropertyMetadataBuilderExtensions.DateTimeDataType(PropertyMetadataBuilderExtensions.EmailAddressDataType(PropertyMetadataBuilderExtensions.PhoneNumberDataType(builder.Property(Function(x) x.ID).ReadOnly().EndProperty().Property(Function(x) x.FirstName).DisplayName("First Name").MaxLength(40).EndProperty().Property(Function(x) x.LastName).DisplayName("Last Name").MaxLength(40).EndProperty().Property(Function(x) x.FullName).Hidden().EndProperty().Property(Function(x) x.Phone).DisplayName("Phone number")).EndProperty().Property(Function(x) x.Email).DisplayName("Email")).EndProperty().Property(Function(x) x.BirthDate).DisplayName("Birth date")).EndProperty()
            builder.Group("Personal").ContainsProperty(Function(x) x.ID).ContainsProperty(Function(x) x.BirthDate).EndGroup().Group("Name").ContainsProperty(Function(x) x.FirstName).ContainsProperty(Function(x) x.LastName).EndGroup().Group("Contact").ContainsProperty(Function(x) x.Phone).ContainsProperty(Function(x) x.Email).EndGroup()
        End Sub
    End Class

    Public Class ReviewMetadata
        Implements IMetadataProvider(Of Customer)

        Private Sub BuildMetadata(ByVal builder As MetadataBuilder(Of Customer)) Implements IMetadataProvider(Of Customer).BuildMetadata
            PropertyMetadataBuilderExtensions.EmailAddressDataType(PropertyMetadataBuilderExtensions.PhoneNumberDataType(builder.Property(Function(x) x.ID).Hidden().EndProperty().Property(Function(x) x.FirstName).Hidden().EndProperty().Property(Function(x) x.LastName).Hidden().EndProperty().Property(Function(x) x.FullName).DisplayName("Full Name").ReadOnly().EndProperty().Property(Function(x) x.Phone).DisplayName("Phone number")).EndProperty().Property(Function(x) x.Email).DisplayName("Email")).EndProperty().Property(Function(x) x.BirthDate).Hidden().EndProperty()
            builder.Group("Name").ContainsProperty(Function(x) x.FullName).EndGroup().Group("Contact").ContainsProperty(Function(x) x.Phone).ContainsProperty(Function(x) x.Email).EndGroup()
        End Sub
    End Class
End Namespace
