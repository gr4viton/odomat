function [dx,dy,dth] = step_sim_vel ( vell, velr, b, th0, t_step)
% calculates one step of the simulation with the time step t_step

relvel = (velr-vell)/b;
if relvel ~= 0
    dth = relvel * t_step ;
    velradius = ((velr+vell)/2/relvel);
    if abs(velradius) < 999999999
        dx = velradius * ( sin(relvel * t_step + th0) - sin(th0) );
        dy = -velradius * ( cos(relvel * t_step + th0) - cos(th0) );
    else
        relvel = 0;
    end
end
if relvel == 0
    average_path = (velr+vell)/2;
    th = (velr-vell)/b + th0;
    dx = average_path * cos(th);
    dy = average_path * sin(th);
end
