UIPanel = {
	csPanel = nil,
	mPriority = UIPriority.PriorityLobbyForSystem,
	mUseMask = false,
	mAlwaysShow = false,
	mHideOtherScreenWhenThisOnTop = false,
}

setmetatable(UIPanel, {__index = UIUtil})

--UIUtil
function UIPanel:OnCreatePanel() end
function UIPanel:OnInitPanel () end
function UIPanel:OnReleasePanel() end

function UIPanel:CreatePanel()
	self:OnCreatePanel()
end

function UIPanel:OnLoadSuccess(csPanel)
	self.csPanel = csPanel
	self:SetupUtil(csPanel.mPanelRoot)
	self:OnInitPanel()
end

function UIPanel:ReleasePanel( )
	self:OnReleasePanel()
end

function UIPanel:Close( )
	if self.csPanel.OnClose then
		self.csPanel:OnClose()
	end
end


