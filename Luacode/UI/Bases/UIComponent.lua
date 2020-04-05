UIComponent = {
	panel = nil,
}

setmetatable(UIComponent, {__index = UIUtil})


function UIComponent:OnCreateComponent( ) end
function UIComponent:OnInitComponent( ) end
function UIComponent:OnReleaseComponent( ) end


function UIComponent:CreateComponent( rectTransform, panel )
	self.panel = panel
	self:OnCreateComponent()
	self:SetupUtil(rectTransform)
	self:OnInitComponent()
end

function UIComponent:OnRelease( )
	self:OnReleaseComponent()
end