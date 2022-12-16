Imports DevExpress.Mvvm
Imports DevExpress.Mvvm.DataAnnotations
Imports System

Namespace DXSample

    Public Class ViewModel
        Inherits ViewModelBase

        Private Property Customer As Customer

        Private Property IsReviewMode As Boolean

        Public Property Source As MetadataExtendedSource
            Get
                Return GetProperty(Function() Me.Source)
            End Get

            Set(ByVal value As MetadataExtendedSource)
                SetProperty(Function() Source, value)
            End Set
        End Property

        Public Sub New()
            Customer = New Customer() With {.FirstName = "Anita", .LastName = "Benson", .BirthDate = New DateTime(1985, 3, 18), .Phone = "(713) 863 813", .Email = "@gmail.com"}
            Source = New MetadataExtendedSource(Customer, MetadataLocator.Create().AddMetadata(GetType(Customer), GetType(ReviewMetadata)))
            IsReviewMode = True
        End Sub

        <Command>
        Public Sub ChangeSource()
            If IsReviewMode Then
                Source = New MetadataExtendedSource(Customer, MetadataLocator.Create().AddMetadata(GetType(Customer), GetType(Metadata)))
                IsReviewMode = False
            Else
                Source = New MetadataExtendedSource(Customer, MetadataLocator.Create().AddMetadata(GetType(Customer), GetType(ReviewMetadata)))
                IsReviewMode = True
            End If
        End Sub
    End Class

    Public Class Customer

        Public Property ID As Integer

        Public Property FirstName As String

        Public Property LastName As String

        Public ReadOnly Property FullName As String
            Get
                Return String.Format("{0} {1}", FirstName, LastName)
            End Get
        End Property

        Public Property Phone As String

        Public Property Email As String

        Public Property BirthDate As Date
    End Class
End Namespace
