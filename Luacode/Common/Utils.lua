function handler( func, target )
	local funcHandler = function ( )
		func(target)
	end
	return funcHandler
end

