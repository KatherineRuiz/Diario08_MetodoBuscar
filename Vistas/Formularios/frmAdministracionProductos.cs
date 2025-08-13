using Modelos.Entidades;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Vistas.Formularios
{
    public partial class frmAdministracionProductos : Form
    {
        public frmAdministracionProductos()
        {
            InitializeComponent();
        }

        private void btnAgregar_Click(object sender, EventArgs e)
        {
            try
            {
                Producto pr = new Producto();

                pr.Nombre = txtNombreProducto.Text;
                pr.Cantidad = Convert.ToInt32(nudCantidad.Text);
                pr.Id_Categoria = Convert.ToInt32(cbCategoria.SelectedValue);
                pr.insertarProductos();
                //Debo llamar al metodo mostrar porque quiero ver lo ultimo que registre
                mostrarProductos();
                MessageBox.Show("Exelente. Datos registrados", "Datos correctos", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error" + ex, "Error de inoformacion", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnBuscar_Click(object sender, EventArgs e)
        {
            try
            {
                dgvProductos.DataSource = null;
                dgvProductos.DataSource = Producto.Buscar(txtBuscar.Text);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void frmAdministracionProductos_Load(object sender, EventArgs e)
        {
            mostrarCategoria();
            mostrarProductos();
        }

        private void mostrarProductos()
        {
            dgvProductos.DataSource = null;
            dgvProductos.DataSource = Producto.cargarProducto();

        }

        private void mostrarCategoria()
        {
            cbCategoria.DataSource = null;
            cbCategoria.DataSource = Categorias.cargarCategoria();
            cbCategoria.DisplayMember = "nombreCategoria";
            cbCategoria.ValueMember = "idCategoria";
            cbCategoria.SelectedIndex = -1;
        }

        private void btnActualizar_Click(object sender, EventArgs e)
        {
            Producto pr = new Producto();
            pr.Nombre = txtNombreProducto.Text;
            pr.Cantidad = Convert.ToInt32(nudCantidad.Text);
            pr.Id_Categoria = Convert.ToInt32(cbCategoria.SelectedValue);
            pr.Id = int.Parse(dgvProductos.CurrentRow.Cells[0].Value.ToString());

            if (pr.actualizarProductos())
            {
                mostrarProductos();
            }
            else
            {
                MessageBox.Show("Error al actualizar la informacion", "Actualizar falló!!");
            }
        }

        private void btnEliminar_Click(object sender, EventArgs e)
        {
            Producto pr = new Producto();
            int id = int.Parse(dgvProductos.CurrentRow.Cells[0].Value.ToString());

            string registroEliminar = dgvProductos.CurrentRow.Cells[1].Value.ToString();
            DialogResult respuesta = MessageBox.Show("¿Quieres eliminar este registro? \n " + registroEliminar, "Eliminando un registro", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (respuesta == DialogResult.Yes)
            {
                if (pr.eliminarProductos(id) == true)
                {
                    MessageBox.Show("Registro eliminado\n" + registroEliminar, "Eliminando", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    mostrarProductos();
                }
            }
            else
            {
                MessageBox.Show("Registro no eliminado", "No seleccionado", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void dgvProductos_DoubleClick(object sender, EventArgs e)
        {
            txtNombreProducto.Text = dgvProductos.CurrentRow.Cells[1].Value.ToString();
            nudCantidad.Text = dgvProductos.CurrentRow.Cells[2].Value.ToString();
        }


    }
    
}
