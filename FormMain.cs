using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Quản_lý_cửa_hàng
{
    public partial class FormMain : Form
    {
        string flag;
        int index, index1;

        //------------------------------------------------------------------

        public FormMain()
        {
            InitializeComponent();
        }

        private void LockControl()
        {
            btThem.Enabled = true;
            btSua.Enabled = true;
            btXoa.Enabled = true;
            btLuu.Enabled = false;
            btTim.Enabled = true;
            btDong.Enabled = true;

            txtMaLoaiHang.ReadOnly = true;
            txtTenLoaiHang.ReadOnly = true;

            btThem.Focus();
        }

        private void UnlockControl()
        {
            btThem.Enabled = false;
            btSua.Enabled = false;
            btXoa.Enabled = false;
            btLuu.Enabled = true;
            btTim.Enabled = false;
            btDong.Enabled = true;

            txtMaLoaiHang.ReadOnly = false;
            txtTenLoaiHang.ReadOnly = false;

            txtMaLoaiHang.Focus();
        }

        public bool check()
        {
            if (string.IsNullOrWhiteSpace(txtMaLoaiHang.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã loại hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaLoaiHang.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenLoaiHang.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên loại hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenLoaiHang.Focus();
                return false;
            }
            return true;
        }

        public bool check2()
        {
            if (string.IsNullOrWhiteSpace(txtTimMaLoaiHang.Text) && string.IsNullOrWhiteSpace(txtTimTenLoaiHang.Text))
            {
                MessageBox.Show("Bạn chưa nhập thông tin cần tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaLoaiHang.Focus();
                return false;
            }
            return true;
        }

        public bool check3()
        {
            if (string.IsNullOrWhiteSpace(txtTimMaHang.Text) && string.IsNullOrWhiteSpace(txtTimTenHang.Text) && string.IsNullOrWhiteSpace(cbbTimLoaiHang.Text) && string.IsNullOrWhiteSpace(txtTimCongTy.Text) && dateTimNSX.Checked == false && dateTimHSD.Checked == false)
            {
                MessageBox.Show("Bạn chưa nhập thông tin cần tìm kiếm!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaLoaiHang.Focus();
                return false;
            }
            return true;
        }

        public bool check1()
        {
            if (string.IsNullOrWhiteSpace(txtMaHang.Text))
            {
                MessageBox.Show("Bạn chưa nhập mã mặt hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtMaHang.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtTenHang.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên mặt hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtTenHang.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(cbbLoaiHang.Text))
            {
                MessageBox.Show("Bạn chưa chọn loại hàng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                cbbLoaiHang.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(txtCtySX.Text))
            {
                MessageBox.Show("Bạn chưa nhập tên công ty sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                txtCtySX.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(dateNgaySanXuat.Text))
            {
                MessageBox.Show("Bạn chưa nhập ngày sản xuất", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateNgaySanXuat.Focus();
                return false;
            }
            if (string.IsNullOrWhiteSpace(dateHanSuDung.Text))
            {
                MessageBox.Show("Bạn chưa nhập hạn sử dụng", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Error);
                dateHanSuDung.Focus();
                return false;
            }
            return true;
        }

        //------------------------------------------------------------------

        private void FormMain_Load(object sender, EventArgs e)
        {
            LockControl();
            LockControlMH();

            //dtLH
            dgvLoaiHang.Rows.Add("LH01", "Thực phẩm");
            dgvLoaiHang.Rows.Add("LH02", "Mỹ phẩm");
            dgvLoaiHang.Rows.Add("LH03", "Văn phòng phẩm");

            //dtMH
            dgvMatHang.Rows.Add("MH01", "Gạo", "Thực phẩm", "Công ty TNHH Lúa Việt Nam", "02/11/2021", "02/11/2026");
            dgvMatHang.Rows.Add("MH02", "Kem chống nắng", "Mỹ phẩm", "Công ty TNHH Shiseido", "16/04/2018", "16/04/2025");
            dgvMatHang.Rows.Add("MH03", "Bút bi", "Văn phòng phẩm", "Công ty Cổ phần Tập đoàn Thiên Long", "02/05/2015", "02/05/2030");

            //comboBox
            string[] items = { "Thực phẩm", "Mỹ phẩm", "Văn phòng phẩm" };
            cbbLoaiHang.Items.AddRange(items);
            cbbTimLoaiHang.Items.AddRange(items);
        }

        private void dgvLoaiHang_SelectionChanged(object sender, EventArgs e)
        {
            index = dgvLoaiHang.CurrentCell.RowIndex;
            if (index < dgvLoaiHang.Rows.Count - 1)
            {
                txtMaLoaiHang.Text = dgvLoaiHang.Rows[index].Cells[0].Value.ToString();
                txtTenLoaiHang.Text = dgvLoaiHang.Rows[index].Cells[1].Value.ToString();
            }
            else
            {
                txtMaLoaiHang.Text = null;
                txtTenLoaiHang.Text = null;
            }
        }

        private void dgvMatHang_SelectionChanged(object sender, EventArgs e)
        {
            index1 = dgvMatHang.CurrentCell.RowIndex;
            if (index1 < dgvMatHang.Rows.Count - 1)
            {
                txtMaHang.Text = dgvMatHang.Rows[index1].Cells[0].Value.ToString();
                txtTenHang.Text = dgvMatHang.Rows[index1].Cells[1].Value.ToString();
                cbbLoaiHang.Text = dgvMatHang.Rows[index1].Cells[2].Value.ToString();
                txtCtySX.Text = dgvMatHang.Rows[index1].Cells[3].Value.ToString();
                dateNgaySanXuat.Text = dgvMatHang.Rows[index1].Cells[4].Value.ToString();
                dateHanSuDung.Text = dgvMatHang.Rows[index1].Cells[5].Value.ToString();
            }
            else
            {
                txtMaHang.Text = null;
                txtTenHang.Text = null;
                cbbLoaiHang.Text = null;
                txtCtySX.Text = null;                
            }    
        }

        private void btDong_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btThem_Click(object sender, EventArgs e)
        {
            UnlockControl();
            flag = "add";

            txtMaLoaiHang.Text = null;
            txtTenLoaiHang.Text = null;
        }

        private void btSua_Click(object sender, EventArgs e)
        {
            UnlockControl();
            flag = "edit";
        }

        private void btTim_Click(object sender, EventArgs e)
        {
            btLamMoiLoaiHang_Click(sender, e);
            string tabNameToOpen = "TimLoaiHang";
            foreach (TabPage tab in tabMain.TabPages)
            {
                if (tab.Name == tabNameToOpen)
                {
                    tabMain.SelectedTab = tab;
                    break;
                }
            }
        }

        private void btLuu_Click(object sender, EventArgs e)
        {
            if (flag == "add")
            {
                if (check() == true)
                {
                    int error = 0;
                    int rowCount = dgvLoaiHang.Rows.Count;
                    for (int i = 0; i < rowCount - 1; i++)
                    {
                        if (dgvLoaiHang[0, i].Value.ToString().ToUpper() == txtMaLoaiHang.Text.ToUpper() || dgvLoaiHang[1, i].Value.ToString().ToUpper() == txtTenLoaiHang.Text.ToUpper())
                        {
                            error++;
                        }
                    }
                    if (error > 0)
                    {
                        MessageBox.Show("Bạn không thể thêm thông tin trùng khớp với loại hàng đã có sẵn trước đó!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dgvLoaiHang.Rows.Add(txtMaLoaiHang.Text.ToUpper(), txtTenLoaiHang.Text);
                        cbbLoaiHang.Items.Add(txtTenLoaiHang.Text);
                        cbbTimLoaiHang.Items.Add(txtTenLoaiHang.Text);
                        dgvLoaiHang.RefreshEdit();
                    }
                }
            }
            else if (flag == "edit")
            {
                if (check() == true)
                {
                    int error = 0;
                    int rowCount = dgvLoaiHang.Rows.Count;
                    for (int i = 0; i < rowCount - 1; i++)
                    {
                        if (dgvLoaiHang[0, i].Value.ToString().ToUpper() == txtMaLoaiHang.Text.ToUpper() && dgvLoaiHang[1, i].Value.ToString().ToUpper() == txtTenLoaiHang.Text.ToUpper())
                        {
                            error++;
                        }
                    }
                    if (error > 0)
                    {
                        MessageBox.Show("Bạn không thể chỉnh sửa thông tin trùng khớp với loại hàng đã có sẵn trước đó!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (index == 0)
                        {
                            MessageBox.Show("Bạn không thể chỉnh sửa loại hàng chính của cửa hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            dgvLoaiHang.Rows[index].Cells[0].Value = txtMaLoaiHang.Text.ToUpper();
                            dgvLoaiHang.Rows[index].Cells[1].Value = txtTenLoaiHang.Text;
                            cbbLoaiHang.Items.Add(txtTenLoaiHang.Text);
                            cbbTimLoaiHang.Items.Add(txtTenLoaiHang.Text);
                            dgvLoaiHang.RefreshEdit();
                        }
                    }
                }
            }
            LockControl();
        }

        private void btXoa_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa loại hàng này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (index < dgvLoaiHang.Rows.Count - 1)
                {                    
                    cbbLoaiHang.Items.Remove(Convert.ToString(dgvLoaiHang[1, index].Value.ToString()));
                    cbbTimLoaiHang.Items.Remove(Convert.ToString(dgvLoaiHang[1, index].Value.ToString()));
                    int i = 0;
                    while (i < dgvMatHang.Rows.Count - 1)
                    {
                        if (dgvLoaiHang[1, index].Value.ToString() == dgvMatHang[2, i].Value.ToString())
                        {
                            dgvMatHang.Rows.RemoveAt(i);
                            i = 0;
                        }
                        else
                        {
                            i++;
                        }    
                    }
                    dgvLoaiHang.Rows.RemoveAt(index);
                    dgvLoaiHang.RefreshEdit();                        
                }                    
            }
        }

        //------------------------------------------------------------------

        private void btDong1_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void LockControlMH()
        {
            btThem1.Enabled = true;
            btSua1.Enabled = true;
            btXoa1.Enabled = true;
            btLuu1.Enabled = false;
            btTim1.Enabled = true;
            btDong1.Enabled = true;

            txtMaHang.ReadOnly = true;
            txtTenHang.ReadOnly = true;
            cbbLoaiHang.Enabled = false;
            txtCtySX.ReadOnly = true;
            dateNgaySanXuat.Enabled = false;
            dateHanSuDung.Enabled = false;

            txtMaHang.Text = null;
            txtTenHang.Text = null;
            txtCtySX.Text = null;
            cbbLoaiHang.Text = null;

            btThem1.Focus();
        }

        private void UnlockControlMH()
        {
            btThem1.Enabled = false;
            btSua1.Enabled = false;
            btXoa1.Enabled = false;
            btLuu1.Enabled = true;
            btTim1.Enabled = false;
            btDong1.Enabled = true;

            txtMaHang.ReadOnly = false;
            txtTenHang.ReadOnly = false;
            cbbLoaiHang.Enabled = true;
            txtCtySX.ReadOnly = false;
            dateNgaySanXuat.Enabled = true;
            dateHanSuDung.Enabled = true;

            txtMaHang.Focus();
        }

        private void btThem1_Click(object sender, EventArgs e)
        {
            UnlockControlMH();
            flag = "add_1";

            txtMaHang.Text = null;
            txtTenHang.Text = null;
            txtCtySX.Text = null;
            cbbLoaiHang.Text = null;
        }

        private void btXoa1_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Bạn có muốn xóa mặt hàng này?", "Cảnh báo", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) == DialogResult.Yes)
            {
                if (index1 < dgvMatHang.Rows.Count - 1)
                {
                    dgvMatHang.Rows.RemoveAt(index1);
                    dgvMatHang.RefreshEdit();
                }                    
            }
        }

        private void cbbLoaiHang_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void btTim1_Click(object sender, EventArgs e)
        {
            btLamMoiMatHang_Click(sender, e);
            string tabNameToOpen = "TimMatHang";
            foreach (TabPage tab in tabMain.TabPages)
            {
                if (tab.Name == tabNameToOpen)
                {
                    tabMain.SelectedTab = tab;
                    break;
                }
            }
        }

        private void btSua1_Click(object sender, EventArgs e)
        {
            UnlockControlMH();
            flag = "edit_1";
        }


        private void btLuu1_Click(object sender, EventArgs e)
        {
            if (flag == "add_1")
            {
                if (check1() == true)
                {
                    int error = 0;
                    int rowCount = dgvMatHang.Rows.Count;
                    for (int i = 0; i < rowCount - 1; i++)
                    {
                        if (dgvMatHang[0, i].Value.ToString().ToUpper() == txtMaHang.Text.ToUpper() || dgvMatHang[1, i].Value.ToString().ToUpper() == txtTenHang.Text.ToUpper() && dgvMatHang[2, i].Value.ToString().ToUpper() == cbbLoaiHang.Text.ToUpper() && dgvMatHang[3, i].Value.ToString().ToUpper() == txtCtySX.Text.ToUpper() && dgvMatHang[4, i].Value.ToString() == dateNgaySanXuat.Text && dgvMatHang[5, i].Value.ToString() == dateHanSuDung.Text)
                        {
                            error++;
                        }
                    }
                    if (error > 0)
                    {
                        MessageBox.Show("Bạn không thể thêm mã hàng hoặc thông tin trùng khớp với sản phẩm đã có trước đó!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        dgvMatHang.Rows.Add(txtMaHang.Text.ToUpper(), txtTenHang.Text, cbbLoaiHang.Text, txtCtySX.Text, dateNgaySanXuat.Text, dateHanSuDung.Text);
                        dgvMatHang.RefreshEdit();
                    }
                }
            }
            else if (flag == "edit_1")
            {
                if (check1() == true)
                {
                    int error = 0;
                    int rowCount = dgvMatHang.Rows.Count;
                    for (int i = 0; i < rowCount - 1; i++)
                    {
                        if (dgvMatHang[0, i].Value.ToString().ToUpper() == txtMaHang.Text.ToUpper() && dgvMatHang[1, i].Value.ToString().ToUpper() == txtTenHang.Text.ToUpper() && dgvMatHang[2, i].Value.ToString().ToUpper() == cbbLoaiHang.Text.ToUpper() && dgvMatHang[3, i].Value.ToString().ToUpper() == txtCtySX.Text.ToUpper() && dgvMatHang[4, i].Value.ToString() == dateNgaySanXuat.Text && dgvMatHang[5, i].Value.ToString() == dateHanSuDung.Text)
                        {
                            error++;
                        }
                    }
                    if (error > 0)
                    {
                        MessageBox.Show("Bạn không thể chỉnh sửa mã hàng hoặc thông tin trùng khớp với sản phẩm đã có trước đó!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    else
                    {
                        if (index1 == 0)
                        {
                            MessageBox.Show("Bạn không thể chỉnh sửa sản phẩm chính của cửa hàng!", "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                        }
                        else
                        {
                            dgvMatHang.Rows[index1].Cells[0].Value = txtMaHang.Text.ToUpper();
                            dgvMatHang.Rows[index1].Cells[1].Value = txtTenHang.Text;
                            dgvMatHang.Rows[index1].Cells[2].Value = cbbLoaiHang.Text;
                            dgvMatHang.Rows[index1].Cells[3].Value = txtCtySX.Text;
                            dgvMatHang.Rows[index1].Cells[4].Value = dateNgaySanXuat.Text;
                            dgvMatHang.Rows[index1].Cells[5].Value = dateHanSuDung.Text;
                            dgvMatHang.RefreshEdit();
                        }
                    }
                }
            }
            LockControlMH();
        }

        private void btDongTimLoaiHang_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }

        private void btTimMatHang_Click(object sender, EventArgs e)
        {
            if (check3() == true)
            {
                dgvTimMatHang.Rows.Clear();
                for (int i = 0; i < dgvMatHang.Rows.Count - 1; i++)
                {
                    if (dgvMatHang[0, i].Value.ToString().ToLower() == txtTimMaHang.Text.ToLower())
                    {
                        dgvTimMatHang.Rows.Add(dgvMatHang[0, i].Value, dgvMatHang[1, i].Value, dgvMatHang[2, i].Value, dgvMatHang[3, i].Value, dgvMatHang[4, i].Value, dgvMatHang[5, i].Value);
                    }
                }
                for (int i = 0; i < dgvMatHang.Rows.Count - 1; i++)
                {
                    if (dgvMatHang[1, i].Value.ToString().ToLower() == txtTimTenHang.Text.ToLower())
                    {
                        dgvTimMatHang.Rows.Add(dgvMatHang[0, i].Value, dgvMatHang[1, i].Value, dgvMatHang[2, i].Value, dgvMatHang[3, i].Value, dgvMatHang[4, i].Value, dgvMatHang[5, i].Value);
                    }
                }
                for (int i = 0; i < dgvMatHang.Rows.Count - 1; i++)
                {
                    if (dgvMatHang[2, i].Value.ToString().ToLower() == cbbTimLoaiHang.Text.ToLower())
                    {
                        dgvTimMatHang.Rows.Add(dgvMatHang[0, i].Value, dgvMatHang[1, i].Value, dgvMatHang[2, i].Value, dgvMatHang[3, i].Value, dgvMatHang[4, i].Value, dgvMatHang[5, i].Value);
                    }
                }
                for (int i = 0; i < dgvMatHang.Rows.Count - 1; i++)
                {
                    if (dgvMatHang[3, i].Value.ToString().ToLower() == txtTimCongTy.Text.ToLower())
                    {
                        dgvTimMatHang.Rows.Add(dgvMatHang[0, i].Value, dgvMatHang[1, i].Value, dgvMatHang[2, i].Value, dgvMatHang[3, i].Value, dgvMatHang[4, i].Value, dgvMatHang[5, i].Value);
                    }
                }
                if (dateTimNSX.Checked == true)
                {
                    for (int i = 0; i < dgvMatHang.Rows.Count - 1; i++)
                    {
                        if (dgvMatHang[4, i].Value.ToString() == dateTimNSX.Text)
                        {
                            dgvTimMatHang.Rows.Add(dgvMatHang[0, i].Value, dgvMatHang[1, i].Value, dgvMatHang[2, i].Value, dgvMatHang[3, i].Value, dgvMatHang[4, i].Value, dgvMatHang[5, i].Value);
                        }
                    }
                }
                if (dateTimHSD.Checked == true)
                {
                    for (int i = 0; i < dgvMatHang.Rows.Count - 1; i++)
                    {
                        if (dgvMatHang[5, i].Value.ToString() == dateTimHSD.Text)
                        {
                            dgvTimMatHang.Rows.Add(dgvMatHang[0, i].Value, dgvMatHang[1, i].Value, dgvMatHang[2, i].Value, dgvMatHang[3, i].Value, dgvMatHang[4, i].Value, dgvMatHang[5, i].Value);
                        }
                    }
                }
                if (dgvTimMatHang.Rows.Count == 1)
                {
                    MessageBox.Show("Không tìm thấy thông tin trùng khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            for (int i = 0; i < dgvTimMatHang.Rows.Count - 2; i++)
            {
                int j = i + 1;
                while (j < dgvTimMatHang.Rows.Count - 1)
                {
                    if (dgvTimMatHang[0, i].Value.ToString().ToUpper() == dgvTimMatHang[0, j].Value.ToString().ToUpper())
                    {
                        dgvTimMatHang.Rows.RemoveAt(j);
                        j = i + 1;
                    }
                    else
                    {
                        j++;
                    }
                }
            }
        }

        private void btTroVeLoaiHang_Click(object sender, EventArgs e)
        {
            string tabNameToOpen = "DMLH";
            foreach (TabPage tab in tabMain.TabPages)
            {
                if (tab.Name == tabNameToOpen)
                {
                    tabMain.SelectedTab = tab;
                    break;
                }
            }
        }

        private void btTroVeMatHang_Click(object sender, EventArgs e)
        {
            string tabNameToOpen = "DMMH";
            foreach (TabPage tab in tabMain.TabPages)
            {
                if (tab.Name == tabNameToOpen)
                {
                    tabMain.SelectedTab = tab;
                    break;
                }
            }
        }

        private void btLamMoiLoaiHang_Click(object sender, EventArgs e)
        {
            dgvLoaiHang.RefreshEdit();
            dgvTimLoaiHang.Rows.Clear();
            txtTimMaLoaiHang.Text = null;
            txtTimTenLoaiHang.Text = null;
        }

        private void btLamMoiMatHang_Click(object sender, EventArgs e)
        {
            dgvMatHang.RefreshEdit();
            dgvTimMatHang.Rows.Clear();
            txtTimMaHang.Text = null;
            txtTimTenHang.Text = null;
            cbbTimLoaiHang.Text = null;
            txtTimCongTy.Text = null;
            dateTimNSX.Checked = false;
            dateTimHSD.Checked = false;
        }

        private void btTimLoaiHang_Click(object sender, EventArgs e)
        {
            if (check2() == true)
            {
                dgvTimLoaiHang.Rows.Clear();
                for (int i = 0; i < dgvLoaiHang.Rows.Count - 1; i++)
                {
                    if (dgvLoaiHang[0, i].Value.ToString().ToLower() == txtTimMaLoaiHang.Text.ToLower())
                    {
                        dgvTimLoaiHang.Rows.Add(dgvLoaiHang[0, i].Value, dgvLoaiHang[1, i].Value);
                    }
                }
                for (int i = 0; i < dgvLoaiHang.Rows.Count - 1; i++)
                {
                    if (dgvLoaiHang[1, i].Value.ToString().ToLower() == txtTimTenLoaiHang.Text.ToLower())
                    {
                        dgvTimLoaiHang.Rows.Add(dgvLoaiHang[0, i].Value, dgvLoaiHang[1, i].Value);
                    }
                }
                if (dgvTimLoaiHang.Rows.Count == 1)
                {
                    MessageBox.Show("Không tìm thấy thông tin trùng khớp!", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            for (int i = 0; i < dgvTimLoaiHang.Rows.Count - 2; i++)
            {
                int j = i + 1;
                while(j < dgvTimLoaiHang.Rows.Count - 1)
                {
                    if (dgvTimLoaiHang[0, i].Value.ToString().ToUpper() == dgvTimLoaiHang[0, j].Value.ToString().ToUpper())
                    {
                        dgvTimLoaiHang.Rows.RemoveAt(j);
                        j = i + 1;
                    }
                    else
                    {
                        j++;
                    }    
                }
            }
        }       

        private void btDongTimMatHang_Click(object sender, EventArgs e)
        {
            DialogResult result;
            result = MessageBox.Show("Bạn có chắc muốn thoát chương trình?", "Xác nhận", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (result == DialogResult.Yes)
            {
                Application.Exit();
            }
        }
    }
}
