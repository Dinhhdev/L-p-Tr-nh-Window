using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
using DevComponents.Tree;

namespace HocMindMapDotnetBar
{
    public partial class Form1 : DevComponents.DotNetBar.Metro.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }
        string strConn = "Server=ThanhTran;Database=CSDL_MindMap;User id=sa;pwd=@Hunggia113";
        SqlConnection conn = null;
        void OpenConnection()
        {
            if (conn == null)
                conn = new SqlConnection(strConn);
            if (conn.State == ConnectionState.Closed)
                conn.Open();
        }
        private void Form1_Load(object sender, EventArgs e)
        {
            NapMindMap();
        }

        private void NapMindMap()
        {
            OpenConnection();
            SqlDataAdapter adapter =
                new SqlDataAdapter("Select* from MindMap where parent is null", conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            if (ds.Tables[0].Rows.Count == 0) return;
            DataRow row = ds.Tables[0].Rows[0];
            int ma =(int) row[0];
            string des = row[2].ToString();
            treeGX1.Nodes.Clear();
            Node root = new Node();
            root.Text = des;
            root.Tag = ma;
            treeGX1.Nodes.Add(root);

            NapMindMap(root, ma);

            root.Expand();

            root.NodeMouseDown += Root_NodeMouseDown;
        }
        int maChon = -1;
        Node selectedNode = null;
        private void Root_NodeMouseDown(object sender, MouseEventArgs e)
        {
            Node node = sender as Node;
            selectedNode = node;
            if (node != null)
                maChon = (int)node.Tag;
        }

        private void NapMindMap(Node root, int ma)
        {
            SqlDataAdapter adapter =
                new SqlDataAdapter("Select * from MindMap where Parent=" + ma, conn);
            DataSet ds = new DataSet();
            adapter.Fill(ds);
            foreach(DataRow row in ds.Tables[0].Rows)
            {
                int Subma = (int)row[0];
                string des = row[2].ToString();
                Node subNode = new Node();
                subNode.Text = des;
                subNode.Tag = Subma;
                root.Nodes.Add(subNode);
                subNode.NodeMouseDown += Root_NodeMouseDown;
                NapMindMap(subNode, Subma);
                
            }
        }

        private void mnuTaoNut_Click(object sender, EventArgs e)
        {
            if(maChon==-1)
            {
                if(treeGX1.Nodes.Count==0)//tạo nút gốc
                {
                    //tự làm nha.. ha ha ha ha
                }
            }
            else
            {
                frmDetail frm = new frmDetail();
                if(frm.ShowDialog()==DialogResult.OK)
                {
                    Node node = new Node();
                    node.Text = frm.txtDesc.Text;
                    selectedNode.Nodes.Add(node);
                    selectedNode.Expand();
                    node.Expand();

                    LuuNode(node.Text, maChon);
                }
            }
        }

        private void LuuNode(string text, int maChon)
        {
            OpenConnection();
            SqlCommand command = new SqlCommand();
            command.CommandType = CommandType.Text;
            command.CommandText =
                "insert into MindMap (Parent,Description) values(@parent,@des)";
            command.Parameters.Add("@parent",SqlDbType.Int).Value=maChon;
            command.Parameters.Add("@des",SqlDbType.NVarChar).Value=text;

            command.Connection = conn;

            int kq = command.ExecuteNonQuery();
            if(kq>0)
            {
                NapMindMap();                
            }
        }
    }
}
