namespace Kendo.Mvc.UI.Tests
{
    using Kendo.Mvc.UI.Tests.Chart;
    using System.Collections;
    using System.Collections.Generic;
    using Xunit;

    public class ChartAreaSeriesSerializerTests
    {
        protected ChartAreaSeries<SalesData, decimal> series;

        public ChartAreaSeriesSerializerTests()
        {
            var chart = ChartTestHelper.CreateChart<SalesData>();
            chart.Data = SalesDataBuilder.GetCollection();
            series = new ChartAreaSeries<SalesData, decimal>(s => s.RepSales);
        }

        [Fact]
        public void Serializes_name()
        {
            series.Name = "SeriesA";
            GetJson(series)["name"].ShouldEqual("SeriesA");
        }

        [Fact]
        public void Should_not_serialize_empty_name()
        {
            series.Name = string.Empty;
            GetJson(series).ContainsKey("name").ShouldBeFalse();
        }

        [Fact]
        public void Serializes_groupNameTemplate()
        {
            series.GroupNameTemplate = "#= series.name #";
            GetJson(series)["groupNameTemplate"].ShouldEqual("#= series.name #");
        }

        [Fact]
        public void Should_not_serialize_empty_groupNameTemplate()
        {
            series.GroupNameTemplate = string.Empty;
            GetJson(series).ContainsKey("groupNameTemplate").ShouldBeFalse();
        }

        [Fact]
        public void Serializes_opacity()
        {
            series.Opacity = 0.5;
            GetJson(series)["opacity"].ShouldEqual(0.5);
        }

        [Fact]
        public void Should_not_serialize_default_opacity()
        {
            GetJson(series).ContainsKey("opacity").ShouldBeFalse();
        }

        [Fact]
        public void Serializes_axis()
        {
            series.Axis = "Axis";
            GetJson(series)["axis"].ShouldEqual("Axis");
        }

        [Fact]
        public void Should_not_serialize_empty_axis()
        {
            series.Axis = string.Empty;
            GetJson(series).ContainsKey("axis").ShouldBeFalse();
        }

        [Fact]
        public void Should_serialize_Tooltip()
        {
            series.Tooltip.Visible = true;
            GetJson(series).ContainsKey("tooltip").ShouldBeTrue();
        }

        [Fact]
        public void Should_not_serialize_default_tooltip()
        {
            GetJson(series).ContainsKey("tooltip").ShouldBeFalse();
        }

        [Fact]
        public void Should_serialize_data_if_set()
        {
            series.Data = new decimal[] { default(decimal) };
            (GetJson(series)["data"] is IEnumerable).ShouldBeTrue();
        }

        [Fact]
        public void Should_not_serialize_data_if_not_set()
        {
            series.Data = null;
            GetJson(series).ContainsKey("data").ShouldBeFalse();
        }

        [Fact]
        public void Should_serialize_field_if_member_is_set()
        {
            series.Member = "RepSales";
            GetJson(series)["field"].ShouldEqual("RepSales");
        }

        [Fact]
        public void Should_not_serialize_field_if_member_is_not_set()
        {
            series.Member = null;
            GetJson(series).ContainsKey("field").ShouldBeFalse();
        }

        [Fact]
        public void Should_serialize_categoryField_if_member_is_set()
        {
            series.CategoryMember = "RepSales";
            GetJson(series)["categoryField"].ShouldEqual("RepSales");
        }

        [Fact]
        public void Should_not_serialize_categoryField_if_member_is_not_set()
        {
            series.CategoryMember = null;
            GetJson(series).ContainsKey("categoryField").ShouldBeFalse();
        }

        [Fact]
        public void Should_serialize_colorField_if_color_member_is_set()
        {
            series.ColorMember = "RepSales";
            GetJson(series)["colorField"].ShouldEqual("RepSales");
        }

        [Fact]
        public void Should_not_serialize_colorField_if_color_member_is_not_set()
        {
            GetJson(series).ContainsKey("colorField").ShouldBeFalse();
        }

        [Fact]
        public void Serializes_type()
        {
            GetJson(series)["type"].ShouldEqual("area");
        }

        [Fact]
        public void Serializes_type_for_vertical_orientation()
        {
            series.Orientation = ChartSeriesOrientation.Vertical;
            GetJson(series)["type"].ShouldEqual("verticalArea");
        }

        [Fact]
        public void Serializes_stack()
        {
            series.Stacked = true;
            GetJson(series)["stack"].ShouldEqual(true);
        }

        [Fact]
        public void Should_not_serialize_default_stack()
        {
            GetJson(series).ContainsKey("stack").ShouldBeFalse();
        }

        [Fact]
        public void Serializes_stack_type_100()
        {
            series.StackType = ChartStackType.Stack100;
            GetJson(series)["stack"].ShouldNotBeNull();
            ((IDictionary<string, object>)GetJson(series)["stack"])["type"].ShouldEqual("100%");
        }

        [Fact]
        public void Serializes_stack_type_normal()
        {
            series.StackType = ChartStackType.Normal;
            GetJson(series)["stack"].ShouldNotBeNull();
            ((IDictionary<string, object>)GetJson(series)["stack"])["type"].ShouldEqual("normal");
        }

        [Fact]
        public void Serializes_aggregate()
        {
            series.Aggregate = ChartSeriesAggregate.Max;
            GetJson(series)["aggregate"].ShouldEqual("max");
        }

        [Fact]
        public void Should_not_serialize_default_aggregate()
        {
            GetJson(series).ContainsKey("aggregate").ShouldBeFalse();
        }

        [Fact]
        public void Should_serializes_line()
        {
            series.Line = new ChartAreaLine(1, "lineColor", ChartDashType.Dot, false);
            GetJson(series).ContainsKey("line").ShouldBeTrue();
        }

        [Fact]
        public void Should_not_seriale_default_width()
        {
            GetJson(series).ContainsKey("line").ShouldBeFalse();
        }

        [Fact]
        public void Should_serialize_label_settings()
        {
            series.Labels.Visible = true;
            GetJson(series).ContainsKey("labels").ShouldEqual(true);
        }

        [Fact]
        public void Should_not_serialize_label_settings_by_default()
        {
            GetJson(series).ContainsKey("labels").ShouldEqual(false);
        }

        [Fact]
        public void Should_serialize_marker_settings()
        {
            series.Markers.Background = "green";
            GetJson(series).ContainsKey("markers").ShouldEqual(true);
        }

        [Fact]
        public void Should_not_serialize_marker_settings_by_default()
        {
            GetJson(series).ContainsKey("markers").ShouldEqual(false);
        }

        [Fact]
        public void Serializes_color()
        {
            series.Color = "Blue";
            GetJson(series)["color"].ShouldEqual("Blue");
        }

        [Fact]
        public void Does_not_serialize_default_color()
        {
            GetJson(series).ContainsKey("color").ShouldBeFalse();
        }

        [Fact]
        public void Should_not_seriale_default_DashType()
        {
            GetJson(series).ContainsKey("dashType").ShouldBeFalse();
        }

        [Fact]
        public void Serializes_MissingValues()
        {
            series.MissingValues = ChartAreaMissingValues.Interpolate;
            GetJson(series)["missingValues"].ShouldEqual("interpolate");
        }

        [Fact]
        public void Should_not_seriale_default_MissingValues()
        {
            GetJson(series).ContainsKey("missingValues").ShouldBeFalse();
        }

        [Fact]
        public void Serializes_ErrorBars()
        {
            series.ErrorBars = new CategoricalErrorBars();
            series.ErrorBars.Value = 1;
            GetJson(series).ContainsKey("errorBars").ShouldBeTrue();
        }

        [Fact]
        public void Should_not_serialize_default_ErrorBars()
        {
            GetJson(series).ContainsKey("errorBars").ShouldBeFalse();
        }

        [Fact]
        public void Serializes_error_low_and_high_name()
        {
            series.ErrorBars.LowMember = "low";
            series.ErrorBars.HighMember = "high";
            GetJson(series).ContainsKey("errorLowField").ShouldBeTrue();
            GetJson(series).ContainsKey("errorHighField").ShouldBeTrue();
        }

        [Fact]
        public void Should_not_serialize_only_error_low_name()
        {
            series.ErrorBars.LowMember = "low";
            GetJson(series).ContainsKey("errorLowField").ShouldBeFalse();
        }

        [Fact]
        public void Should_not_serialize_only_error_high_name()
        {
            series.ErrorBars.HighMember = "high";
            GetJson(series).ContainsKey("errorHighField").ShouldBeFalse();
        }

        [Fact]
        public void Should_not_serialize_default_error_low_and_high_name()
        {
            GetJson(series).ContainsKey("errorLowField").ShouldBeFalse();
            GetJson(series).ContainsKey("errorHighField").ShouldBeFalse();
        }

        protected static IDictionary<string, object> GetJson(IChartSeries series)
        {
            return series.CreateSerializer().Serialize();
        }
    }
}
