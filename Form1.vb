Public Class Form1
    ' Tracks if donor is registered
    Private donorRegistered As Boolean = False

    ' Auto-increment counters for IDs 
    Private donorIDCounter As Integer = 1000
    Private donationIDCounter As Integer = 1
    Private orgIDCounter As Integer = 1

    'Lists to store organizations 
    Private organizations As New List(Of clsOrganisation)
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        ' Disable donation fields initially
        txtAmount.Enabled = False
        txtFoodType.Enabled = False
        txtQuantity.Enabled = False
    End Sub
    Private Sub btnRegister_Click(sender As Object, e As EventArgs) Handles btnRegister.Click
        ' Collect donor inputs
        Dim donorName As String = txtDonorName.Text.Trim()
        Dim donorContact As String = txtContact.Text.Trim()

        ' Validate inputs 
        If donorName = "" Or donorContact = "" Then
            MessageBox.Show("All fields are required!", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not donorName.All(Function(c) Char.IsLetter(c) Or Char.IsWhiteSpace(c)) Then
            MessageBox.Show("Donor Name must contain letters only!", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not IsNumeric(donorContact) Then
            MessageBox.Show("Donor Contact must be numeric!", "Registration Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        'Generate Donor ID automatically
        Dim donorID As String = donorIDCounter.ToString()
        txtDonorID.Text = donorID
        donorIDCounter += 1

        donorRegistered = True
        btnAddDonation.Enabled = True

        MessageBox.Show("Registration successful! Your Donor ID is: " & donorID, "Registered", MessageBoxButtons.OK, MessageBoxIcon.Information)
    End Sub
    Private Sub btnAddDonation_Click(sender As Object, e As EventArgs) Handles btnAddDonation.Click
        If Not donorRegistered Then
            MessageBox.Show("You must register before making a donation.", "Registration Required", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Determine selected donation type
        Dim donationDetails As String = ""
        If radFood.Checked Then
            donationDetails = "Food"
        ElseIf radFunds.Checked Then
            donationDetails = "Funds"
        Else
            MessageBox.Show("Please select a donation type (Food or Funds).", "Missing Selection", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        ' Validate donation amount if Funds selected
        Dim donationAmountText As String = txtAmount.Text.Trim()
        Dim donationAmount As Decimal
        If donationAmountText <> "" Then
            If Not Decimal.TryParse(donationAmountText, donationAmount) OrElse donationAmount < 0 Then
                MessageBox.Show("Please enter a valid donation amount (0 or higher).", "Invalid Amount", MessageBoxButtons.OK, MessageBoxIcon.Warning)
                Exit Sub
            End If
        Else
            donationAmount = 0
        End If

        ' Assign donation ID and capture date/time
        Dim donationID As Integer = donationIDCounter
        donationIDCounter += 1
        Dim donationDate As String = DateTime.Now.ToString("dd/MM/yyyy HH:mm")

        lstDisplay.Items.Add("----- Donor Details -----")
        lstDisplay.Items.Add("Date/Time: " & donationDate)
        lstDisplay.Items.Add("Name: " & txtDonorName.Text)
        lstDisplay.Items.Add("ID: " & txtDonorID.Text)
        lstDisplay.Items.Add("Contact: " & txtContact.Text)

        If radFunds.Checked Then
            lstDisplay.Items.Add("Donation Details: Funds")
            lstDisplay.Items.Add("Amount: R" & txtAmount.Text)
        End If

        If radFood.Checked Then
            lstDisplay.Items.Add("Donation Details: Food")
            lstDisplay.Items.Add("Food Type: " & txtFoodType.Text)
            lstDisplay.Items.Add("Quantity: " & txtQuantity.Text)
        End If

        lstDisplay.Items.Add("================================")
        MessageBox.Show("Donation added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

        ' Clear donation-specific inputs
        txtAmount.Clear()
        txtFoodType.Clear()
        txtQuantity.Clear()
        radFood.Checked = False
        radFunds.Checked = False
    End Sub
    Private Sub btnAddOrganisation_Click(sender As Object, e As EventArgs) Handles btnAddOrganisation.Click
        ' Validate required fields
        If txtOrgName.Text.Trim() = "" Or txtContactPerson.Text.Trim() = "" Or txtLocation.Text.Trim() = "" Then
            MessageBox.Show("Please fill all organization fields!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        If Not IsNumeric(txtContactPerson.Text.Trim()) Then
            MessageBox.Show("Organization Contact Number must be numeric!", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Exit Sub
        End If

        Dim org As New clsOrganisation
        org.OrgID = orgIDCounter
        org.OrgName = txtOrgName.Text.Trim()
        org.ContactPerson = txtContactPerson.Text.Trim()
        org.Address = txtLocation.Text.Trim()
        orgIDCounter += 1

        organizations.Add(org)

        lstDisplay.Items.Add("        Organization Details          ")
        lstDisplay.Items.Add("Organization Name: " & org.OrgName)
        lstDisplay.Items.Add("Contact Person: " & org.ContactPerson)
        lstDisplay.Items.Add("Location: " & org.Address)
        lstDisplay.Items.Add("================================")

        MessageBox.Show("Organization added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information)

    End Sub
    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        If MessageBox.Show("Are you sure you want to exit the system?", "Exit Program", MessageBoxButtons.YesNo, MessageBoxIcon.Question) = DialogResult.Yes Then
            Application.Exit()
        End If
    End Sub
    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        txtDonorName.Clear()
        txtDonorID.Clear()
        txtContact.Clear()
        txtAmount.Clear()
        txtFoodType.Clear()
        txtQuantity.Clear()
        txtOrgName.Clear()
        txtContactPerson.Clear()
        txtLocation.Clear()
        radFood.Checked = False
        radFunds.Checked = False
        lstDisplay.Items.Clear()
    End Sub
    ' Enable/Disable Donation Fields
    Private Sub radFunds_CheckedChanged(sender As Object, e As EventArgs) Handles radFunds.CheckedChanged
        If radFunds.Checked Then
            txtAmount.Enabled = True
            txtFoodType.Enabled = False
            txtQuantity.Enabled = False
            txtFoodType.Clear()
            txtQuantity.Clear()
        End If
    End Sub

    Private Sub radFood_CheckedChanged(sender As Object, e As EventArgs) Handles radFood.CheckedChanged
        If radFood.Checked Then
            txtAmount.Enabled = False
            txtAmount.Clear()
            txtFoodType.Enabled = True
            txtQuantity.Enabled = True
        End If
    End Sub

End Class