function [dx,dy,dth] = step_sim ( rob, t_step)
% calculates one step of the simulation with the time step t_step
% type
% 'vel'
% 'velu'
% 'path'

vell = rob.vellr(1);
velr = rob.vellr(2);
% b = rob.base;
% th0 = rob.th;
% x0 = rob.pos(1);
% y0 = rob.pos(2);

relvel = (velr-vell)/b;
if relvel ~= 0
    dth = relvel * t_step ;
    velradius = (velr+vell)/2/relvel;
    if velradius < 999999999
        dx = velradius * ( sin(relvel * t_step + th0) - sin(th0) );
        dy = velradius * ( cos(relvel * t_step + th0) - cos(th0) );
    else
        relvel = 0;
    end
end
if relvel == 0
    average_path = (vell+velr)/2;
    th = (vell-velr)/b + th0;
    dx = average_path * cos(th);
    dy = average_path * sin(th);
end

% if type == 'velu' || type = 'pathu'
%     update_robot(rob, dx, dy, dth);
% end
% rob