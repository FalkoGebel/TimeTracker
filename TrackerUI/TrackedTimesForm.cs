using System.Data;
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
            output.Columns.Add(Properties.Resources.TTGRID_ACTIVE_HEADER, typeof(bool));

            // Lines
            foreach (var trackedTime in TrackerLogic.GetTrackedTimes())
            {
                output.Rows.Add(trackedTime.Category.Name,
                                trackedTime.Start,
                                trackedTime.End,
                                trackedTime.Duration,
                                trackedTime.Category.Active);
            }

            return output;
        }
    }
}
