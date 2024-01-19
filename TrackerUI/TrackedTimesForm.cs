using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TrackerLibrary;

namespace TrackerUI
{
    public partial class TrackedTimesForm : Form
    {
        public TrackedTimesForm()
        {
            InitializeComponent();
            TrackedTimesGridView.DataSource = CreateTrackedTimesGridDataTable();
        }

        private DataTable CreateTrackedTimesGridDataTable()
        {
            DataTable output = new();

            // Header
            output.Columns.Add(Properties.Resources.TTGRID_CATEGORY_HEADER);
            output.Columns.Add(Properties.Resources.TTGRID_START_HEADER);
            output.Columns.Add(Properties.Resources.TTGRID_END_HEADER);
            output.Columns.Add(Properties.Resources.TTGRID_DURATION_HEADER);

            // Lines
            foreach (var trackedTime in TrackerLogic.GetTrackedTimes())
            {
                output.Rows.Add(trackedTime.Category.Name, trackedTime.Start, trackedTime.End, trackedTime.Duration);
                /*
                output.Rows.Add(new object[]
                {
                    trackedTime.Category.Name,
                    trackedTime.Start,
                    trackedTime.End,
                    trackedTime.Duration
                });
                */
            }

            return output;
        }
    }
}
