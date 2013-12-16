<%--Class used to create custom layout widget

If this layout widget is a part of a Sitefinity module,
you can register it in the site's toolbox by adding this to the module's Install/Upgrade method(s):
initializer.Installer
    .Toolbox(CommonToolbox.Layouts)
        .LoadOrAddSection(SectionName)
            .SetTitle(SectionTitle) // When creating a new section
            .SetDescription(SectionDescription) // When creating a new section
            .LoadOrAddWidget<LayoutControl>("GridsOfThree")
                .SetTitle("GridsOfThree")
                .SetDescription("GridsOfThree")
                .LocalizeUsing<ModuleResourceClass>() //Optional
                .SetCssClass(WidgetCssClass) // You can use a css class to add an icon (Optional)
                .SetParameters(new NameValueCollection()
                {
                    { "layoutTemplate", "~/Custom/Layouts/GridsOfThree.ascx" },
                })
            .Done()
        .Done()
    .Done();

You can see also http://www.sitefinity.com/documentation/gettingstarted/creating-custom-sitefinity-layout-widget-controls --%>

<div runat="server" class="sf_cols grids_1_of_3">
    <div runat="server" class="sf_colsOut sf_3cols_1_33 grid_1_of_3 images_1_of_3">
        <div runat="server" class="sf_colsIn sf_3cols_1in_33">
        </div>
    </div>
    <div runat="server" class="sf_colsOut sf_3cols_2_34 grid_1_of_3 images_1_of_3">
        <div runat="server" class="sf_colsIn sf_3cols_2in_34">            
        </div>
    </div>
    <div runat="server" class="sf_colsOut sf_3cols_3_33 grid_1_of_3 images_1_of_3">
        <div  runat="server" class="sf_colsIn sf_3cols_3in_33">            
        </div>
    </div>
    <div runat="server" class="clear"></div>
</div>