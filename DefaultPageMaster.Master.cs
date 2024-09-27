using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace de1
{
    public partial class DefaultPageMaster : System.Web.UI.MasterPage
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                BindCategories();
            }
        }

        private void BindCategories()
        {
            // Ví dụ về cách lấy dữ liệu từ cơ sở dữ liệu
            string query = "SELECT CategoryID, CategoryName, (SELECT COUNT(*) FROM Courses WHERE CategoryID = Categories.CategoryID) AS CourseCount FROM Categories";

            using (SqlConnection conn = new SqlConnection("YourConnectionString"))
            {
                SqlCommand cmd = new SqlCommand(query, conn);
                conn.Open();
                SqlDataReader reader = cmd.ExecuteReader();

                // Bind dữ liệu vào DataList
                dlCategories.DataSource = reader;
                dlCategories.DataBind();
            }
        }
    }
}