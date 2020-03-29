ILuaPanelInterface = {
	LoadSuccess = function (self, csPanel, luaPath)
		self:LoadSuccess(csPanel, luaPath)
	end,

	Release = function ( self )
		self:Release()
	end,


    GetPriority = function ( self )
    	return self:GetPriority()
    end,


    GetUseMask = function ( self )
    	return self:GetUseMask()
    end,

    GetAlwaysShow = function ( self )
    	return self:GetAlwaysShow()
    end,

    GetHideOtherScreenWhenThisOnTop = function ( self )
    	return self:GetHideOtherScreenWhenThisOnTop()
    end,
}
