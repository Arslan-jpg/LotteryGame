Public Class Form1

    Dim brpobjeda As Integer = 0
    Dim brtacnih As Integer = 0

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load

        Dim Uputstvo As ToolTip = New ToolTip
        Uputstvo.SetToolTip(pbPomoc, "Kliknite za uputstvo")

        pbBroj1.SizeMode = PictureBoxSizeMode.Zoom
        pbBroj2.SizeMode = PictureBoxSizeMode.Zoom
        pbBroj3.SizeMode = PictureBoxSizeMode.Zoom
        pbBroj4.SizeMode = PictureBoxSizeMode.Zoom
        pbBroj5.SizeMode = PictureBoxSizeMode.Zoom
        pbBroj6.SizeMode = PictureBoxSizeMode.Zoom
        pbBroj7.SizeMode = PictureBoxSizeMode.Zoom
        pbBroj8.SizeMode = PictureBoxSizeMode.Zoom
        pbBroj9.SizeMode = PictureBoxSizeMode.Zoom
        pbBroj10.SizeMode = PictureBoxSizeMode.Zoom

        pbIzbor1.SizeMode = PictureBoxSizeMode.Zoom
        pbIzbor2.SizeMode = PictureBoxSizeMode.Zoom
        pbIzbor3.SizeMode = PictureBoxSizeMode.Zoom

        pbRezultat1.SizeMode = PictureBoxSizeMode.Zoom
        pbRezultat2.SizeMode = PictureBoxSizeMode.Zoom
        pbRezultat3.SizeMode = PictureBoxSizeMode.Zoom
        pbRezultat4.SizeMode = PictureBoxSizeMode.Zoom
        pbRezultat5.SizeMode = PictureBoxSizeMode.Zoom

        pbPomoc.SizeMode = PictureBoxSizeMode.Zoom

        btnProvjera.Enabled = False

    End Sub

    ' Izbor brojeva 

    Private Sub pbBroj1_MouseDoubleClick(sender As Object, e As MouseEventArgs) Handles pbBroj9.MouseDoubleClick, pbBroj8.MouseDoubleClick, pbBroj7.MouseDoubleClick,
        pbBroj6.MouseDoubleClick, pbBroj5.MouseDoubleClick, pbBroj4.MouseDoubleClick, pbBroj3.MouseDoubleClick, pbBroj2.MouseDoubleClick, pbBroj10.MouseDoubleClick, pbBroj1.MouseDoubleClick


        If pbIzbor1.Tag = sender.tag Then
            MessageBox.Show("Taj broj ste već izabrali, odaberite neki drugi!", "Greška!")
            Exit Sub
        ElseIf pbIzbor2.Tag = sender.Tag Then
            MessageBox.Show("Taj broj ste već izabrali, odaberite neki drugi!", "Greška!")
            Exit Sub
        Else
            If pbIzbor1.Image Is Nothing Then
                pbIzbor1.Image = sender.Image
                pbIzbor1.Tag = sender.tag
            ElseIf pbIzbor2.Image Is Nothing Then
                pbIzbor2.Image = sender.Image
                pbIzbor2.Tag = sender.tag
            ElseIf pbIzbor3.Image Is Nothing Then
                pbIzbor3.Image = sender.Image
                pbIzbor3.Tag = sender.tag
            End If
        End If

    End Sub

    'Rezultati

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnStart.Click

        If pbIzbor3.Tag = "" Then
            MessageBox.Show("Niste odabrali tri kuglice.", "Greška!")
            Exit Sub
        End If

        Dim NizIzbora(3) As Integer
        Dim Rezultati(4) As Integer

        Rezultati = MakeMeRich()

        Dim ucitavanjeSl As String = System.IO.Directory.GetCurrentDirectory() + "\slike\br"

        pbRezultat1.Image = Image.FromFile(ucitavanjeSl + Rezultati(1).ToString + ".png")
        pbRezultat1.Tag = Rezultati(1).ToString

        pbRezultat2.Image = Image.FromFile(ucitavanjeSl + Rezultati(2).ToString + ".png")
        pbRezultat2.Tag = Rezultati(2).ToString

        pbRezultat3.Image = Image.FromFile(ucitavanjeSl + Rezultati(3).ToString + ".png")
        pbRezultat3.Tag = Rezultati(3).ToString

        pbRezultat4.Image = Image.FromFile(ucitavanjeSl + Rezultati(4).ToString + ".png")
        pbRezultat4.Tag = Rezultati(4).ToString

        pbRezultat5.Image = Image.FromFile(ucitavanjeSl + Rezultati(0).ToString + ".png")
        pbRezultat5.Tag = Rezultati(0).ToString

        NizIzbora(0) = pbIzbor1.Tag
        NizIzbora(1) = pbIzbor2.Tag
        NizIzbora(2) = pbIzbor3.Tag

        Dim brojac As Integer = 0

        Do While brojac < 3

            If Rezultati.Contains(NizIzbora(brojac)) Then
                brtacnih += 1
            End If

            brojac += 1

        Loop

        btnProvjera.Enabled = True
        btnOcisti.Enabled = False
        btnStart.Enabled = False

    End Sub

    Private Sub btnOcisti_Click(sender As Object, e As EventArgs) Handles btnOcisti.Click

        pbIzbor1.Image = Nothing
        pbIzbor1.Tag = ""
        pbIzbor2.Image = Nothing
        pbIzbor2.Tag = ""
        pbIzbor3.Image = Nothing
        pbIzbor3.Tag = ""

        btnProvjera.Enabled = False

    End Sub

    Public Function MakeMeRich() As Integer()

        Dim Rezultati(4) As Integer
        Dim RND As New Random(Now.Millisecond)

        Dim NoviBr As Integer
        Dim Brojac As Integer

        Do

            NoviBr = RND.Next(1, 11)

            If Not (Rezultati.Contains(NoviBr)) Then

                Rezultati(Brojac) = NoviBr

                Brojac += 1

            End If

        Loop Until Brojac = 5

        MakeMeRich = Rezultati

    End Function

    Private Sub pbPomoc_Click(sender As Object, e As EventArgs) Handles pbPomoc.Click

        MessageBox.Show("U prvom panelu se nalaze ponuđene kuglice sa rednim brojevima. Duplim klikom odaberite tri kuglice za igru!" + vbNewLine + vbNewLine +
                        "U drugom panelu se nalazi Vaš trenutni izbor. Klikom na tipku očisti izbor možete ponovo birati!" + vbNewLine + vbNewLine +
                        "Kada ste odabrali kuglice, kliknite start kako biste odigrali igru. U trećem panelu će vam se prikazati rezultat." + vbNewLine + vbNewLine +
                        "Sva tri Vaša broja moraju izaći u rezultatu kako bi pobijedili! Sretno!", "Uputstvo")

    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick

        If pbIzbor1.Tag = "" Then
            If pbIzbor1.BorderStyle = BorderStyle.None Then
                pbIzbor1.BorderStyle = BorderStyle.FixedSingle
            Else
                pbIzbor1.BorderStyle = BorderStyle.None
            End If
        Else
            pbIzbor1.BorderStyle = BorderStyle.None
        End If

        If pbIzbor2.Tag = "" Then
            If pbIzbor2.BorderStyle = BorderStyle.None Then
                pbIzbor2.BorderStyle = BorderStyle.FixedSingle
            Else
                pbIzbor2.BorderStyle = BorderStyle.None
            End If
        Else
            pbIzbor2.BorderStyle = BorderStyle.None
        End If

        If pbIzbor3.Tag = "" Then
            If pbIzbor3.BorderStyle = BorderStyle.None Then
                pbIzbor3.BorderStyle = BorderStyle.FixedSingle
            Else
                pbIzbor3.BorderStyle = BorderStyle.None
            End If
        Else
            pbIzbor3.BorderStyle = BorderStyle.None
        End If

    End Sub

    Private Sub btnProvjera_Click(sender As Object, e As EventArgs) Handles btnProvjera.Click

        If brtacnih = 3 Then
            MessageBox.Show("Pobjeda!" + vbNewLine + "Pogodili ste sve brojeve, čestitam!", "Pobjedili ste!")
            brpobjeda += 1
        ElseIf brtacnih > 0 Then
            MessageBox.Show("Broj pogođenih brojeva: " + brtacnih.ToString + vbNewLine + "Više sreće drugi put!",
                            "Niste pobijedili", MessageBoxButtons.OK, MessageBoxIcon.Information)
        Else
            MessageBox.Show("Niste pogodili niti jedan broj, probajte ponovno!", "Niste pobijedili",
                            MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If

        lblPobjede.Text = "Broj pobjeda: " + brpobjeda.ToString
        brtacnih = 0

        btnStart.Enabled = True
        btnOcisti.Enabled = True
        btnProvjera.Enabled = False
    End Sub
End Class
