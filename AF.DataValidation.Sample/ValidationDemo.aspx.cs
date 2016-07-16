using System;
using System.Web.UI.WebControls;
using System.Web.UI;
using Architecture.Foundation.DataValidator;
using System.Collections.Generic;
using System.Drawing;

namespace AFDataValidation
{
    public partial class ValidationDemo : Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Session["employee"] = null;
                BindEmployeeGrid();
            }


            lblMessage.Text = String.Empty;
        }

        private void BindEmployeeGrid()
        {
            List<ValidationEntity> empList;
            if (Session["employee"] == null)
            {
                // var userContext = AF.EntityService.CreateUserContext(AF.SecurityService.Management.GetLoggedInUserID, AF.SecurityService.Management.GetLoggedInUserName);
                var buisnessLayer = new ValidationDemoDAL();
                empList = buisnessLayer.GetEmployeeList();
                Session["employee"] = empList;
            }
            else
                empList = Session["employee"] as List<ValidationEntity>;

            Employee.DataSource = empList;
            Employee.DataBind();
        }

        /// <summary>
        /// Set Validation Operations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void btnSubmit_Click(object sender, EventArgs e)
        {
            var employeeEntity = new ValidationEntity();
            employeeEntity.EmpID = Guid.NewGuid();
            employeeEntity.Name = txtName.Text;
            employeeEntity.Address = txtAddress.Text;
            employeeEntity.Phone = txtPhone.Text;
            employeeEntity.EMail = txtEMail.Text;

            //Set Add operation
            employeeEntity.ValidateOperation = ValidateOperations.Add;

            try
            {
                var validateResult = AFValidator.DataValidation(employeeEntity);
                if (validateResult.IsValid)
                {
                    // var userContext = AF.EntityService.CreateUserContext(AF.SecurityService.Management.GetLoggedInUserID, AF.SecurityService.Management.GetLoggedInUserName);
                    var buisnessLayer = new ValidationDemoDAL();
                    var result = buisnessLayer.AddEmployee(employeeEntity);
                    Session["employee"] = null;
                    BindEmployeeGrid();

                    if (result.IsValid)
                    {
                        lblMessage.ForeColor = Color.Black;
                        txtName.Text = String.Empty;
                        txtAddress.Text = String.Empty;
                        txtPhone.Text = String.Empty;
                        txtEMail.Text = String.Empty;
                        lblMessage.Text = "Record added successfuly";
                    }
                    else
                    {
                        lblMessage.ForeColor = Color.Red;
                        foreach (var msg in result.Message)
                            lblMessage.Text = msg + "<br/>";
                    }
                }



            }
            catch (Exception ex)
            {
                //Log Error

            }
        }

        protected void Employee_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            Employee.PageIndex = e.NewPageIndex;
            BindEmployeeGrid();
        }

        protected void Employee_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {
            var employeeID = new Guid(e.Keys[0].ToString());

            // var userContext = AF.EntityService.CreateUserContext(AF.SecurityService.Management.GetLoggedInUserID, AF.SecurityService.Management.GetLoggedInUserName);
            var buisnessLayer = new ValidationDemoDAL();
            buisnessLayer.DeleteEmployee(employeeID);

            Session["employee"] = null;
            BindEmployeeGrid();
        }

        /// <summary>
        /// Set Validation Operations
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        protected void Employee_RowUpdating(object sender, GridViewUpdateEventArgs e)
        {
            var employeeID = new Guid(e.Keys[0].ToString());
            TextBox Address = (TextBox)Employee.Rows[e.RowIndex].FindControl("txtAddress");
            TextBox EMail = (TextBox)Employee.Rows[e.RowIndex].FindControl("txtEMail");
            TextBox Phone = (TextBox)Employee.Rows[e.RowIndex].FindControl("txtPhone");

            var emp = new ValidationEntity { EmpID = employeeID, Address = Address.Text, EMail = EMail.Text, Phone = Phone.Text };

            //Set update operation
            emp.ValidateOperation = ValidateOperations.Update;

            var validateResult = AFValidator.DataValidation(emp);
            if (validateResult.IsValid)
            {
                // var userContext = AF.EntityService.CreateUserContext(AF.SecurityService.Management.GetLoggedInUserID, AF.SecurityService.Management.GetLoggedInUserName);
                var buisnessLayer = new ValidationDemoDAL();
                var result = buisnessLayer.UpdateEmployee(emp);
            }

            Employee.EditIndex = -1;
            Session["employee"] = null;
            BindEmployeeGrid();
        }

        protected void Employee_RowEditing(object sender, GridViewEditEventArgs e)
        {
            Employee.EditIndex = e.NewEditIndex;
            Session["employee"] = null;
            BindEmployeeGrid();
        }

        protected void Employee_RowCancelingEdit(object sender, GridViewCancelEditEventArgs e)
        {
            Employee.EditIndex = -1;
            Session["employee"] = null;
            BindEmployeeGrid();
        }
    }
}