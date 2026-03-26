Public Class Donation
    ' Properties
    Private _donationID As Integer
    Private _donorName As String
    Private _donationDateils As String
    Private _amount As Decimal

    ' Constructor
    Public Sub New(donationID As Integer, donorName As String, donatDateils As String, amount As Decimal)
        _donationID = donationID
        _donorName = donorName
        _donationDateils = donatDateils
        _amount = amount
    End Sub

    ' Property Getters and Setters
    Public Property DonationID() As Integer
        Get
            Return _donationID
        End Get
        Set(value As Integer)
            _donationID = value
        End Set
    End Property

    Public Property DonorName() As String
        Get
            Return _donorName
        End Get
        Set(value As String)
            _donorName = value
        End Set
    End Property

    Public Property DonationType() As String
        Get
            Return _donationDateils
        End Get
        Set(value As String)
            _donationDateils = value
        End Set
    End Property

    Public Property Amount() As Decimal
        Get
            Return _amount
        End Get
        Set(value As Decimal)
            _amount = value
        End Set
    End Property

    ' Methods
    Public Function DisplayDonationInfo() As String
        Return $"Donation ID: {_donationID}" & vbCrLf &
               $"Donor Name: {_donorName}" & vbCrLf &
               $"Donation Type: {_donationDateils}" & vbCrLf &
               $"Amount: R{_amount}" & vbCrLf

    End Function

    ' Optional: Check if donation meets mandatory minimum
    Public Function IsMandatoryMet(minAmount As Decimal) As Boolean
        Return _amount >= minAmount
    End Function
End Class
