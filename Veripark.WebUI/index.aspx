<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="Veripark.WebUI.index" %>

<!DOCTYPE html>

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <title></title>
    <link href="Content/bootstrap.min.css" rel="stylesheet" />

</head>
<body>
    <form id="form1" runat="server">
        <div class="container">
            <div class="row mt-5">
                <div class="col-md-3">
                    book checked out
                </div>
                <div class="col-md-9">
                    <input type="date" runat="server" id="clnDateCheck" class="form-control" />
                </div>
            </div>

            <div class="row mt-2">
                <div class="col-md-3">
                    book is returned
                </div>
                <div class="col-md-9">
                    <input type="date" runat="server" id="clnDateReturn" class="form-control" />
                </div>
            </div>

            <div class="row mt-2">
                <div class="col-md-3">
                    Country select
                </div>
                <div class="col-md-9">
                    <select id="drpCountry" cssclass="form-control" class="form-control" multiple="true" runat="server">
                    </select>
                </div>
            </div>

            <div class="row mt-2">
                <div class="col-md-3">
                    <asp:Button ID="btnCalculate" OnClick="btnCalculate_Click" runat="server" class="btn btn-success" Text="Calculate" />
                </div>
            </div>

            <div class="row mt-2">
                <div class="col-md-12 text-center">
                    <span id="lblResult" class="text-center" style="color:red; font-size:large;" runat="server"></span>
                </div>
            </div>
        </div>
        <input type="hidden" id="hdSelectCountry" runat="server" />
    </form>
    <script src="Scripts/bootstrap.min.js"></script>
    <script src="Scripts/jquery-3.6.0.min.js"></script>
    <script>
        $(document).ready(function () {

            $("#drpCountry").change(function () {
                var selectCountry = $("#drpCountry").val();
                $("#hdSelectCountry").val(selectCountry);
            });
        });
    </script>

</body>
</html>
