UIPanel = {

}

setmetatable(UIPanel, {__index = UIUtil})
--setmetatable(UIPanel, {__index = events})

function UIPanel:OnLoadSuccess( )
end

function UIPanel:OnRelease( )
end

function UIPanel:OnClose( )
	self.mCsPanel:OnClose()
end

function UIPanel:GetPriority( )
	return UIPriority.PriorityLobbyForSystem
end

function UIPanel:GetUseMask( )
	return false
end

function UIPanel:GetAlwaysShow( )
	return false
end

function UIPanel:GetHideOtherScreenWhenThisOnTop( )
	return false
end
