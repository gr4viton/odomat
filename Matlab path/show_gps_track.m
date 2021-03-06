function xyth = show_gps_track(cislo_mereni, plotAsec, utc_startup, utc_offset, utc_yawtime, plot_text, utc_end)
% clc; clear; close all;
% v metrech vsecko
g0 = struct(...
    'utc', 0,...
    'utc_startup', 0,...
    'utc_offset', 0,...
    'utc_yawtime', 0,...
    'plotAsec', 8,...
    'e', 0,...  %after transformation
    'n', 0,...
    'eM', 0,... %measured
    'nM', 0,... 
    'u', 0,...
    'yaw', 0,...
    'tilt', 0,...
    'K', 0.633,...  %height of the reference antenna from ground = krabice
    'H', 1.007,... % delka ramene
    'V', 0.837,... % vyska ramene nad zemi
    'L', 0,... % prepocitana delka po aplikaci tilt
    'x', 0,...
    'y', 0,...
    'th', 0,...
    'lastx', 0,...
    'lasty', 0,...
    'rR', 0.10,... %radius of wheels [m]
    'rL', 0.10,...
    'b', 0.675,... % podstava [m]
    'digits_rob', 32,...
    'color1', [0.6 0.6 0.6],...
    'color2', [0 0 0],... 
    'robline', '--',...
    'plot_period', 140,...
    'robot_visible', 1,...
    'variance_visible', 1,...
    'pix', 0.20,... %pixels of covariance matrix
    'robot_radius', 0.02); % radius of its drawen circle

g0.plotAsec = plotAsec;
g0.utc_startup = utc_startup;
g0.utc_offset = utc_offset;
g0.utc_yawtime = utc_yawtime;

disp(g0.H);
filename = strcat( 'D:\EDUC\bak_bakalarka\mereni\backupSt\_st\01 � kopie (' , num2str(cislo_mereni), ')\gpslog_parsed.txt');
gps = parse_gps(g0, filename);

% this_sec_plotted = 0;
steps = size(gps.utc,1);
disp(steps)

hold on;
% figure(1);
chsv = hsv( floor(steps)+2);
% chsv
chsv2 = hsv( 1000 );
% disp([gps.e gps.n])
    lastx = 0; lasty = 0;
    
    
    
r = gps;
%% nato� GPS co nejlepe - 
% orientuj se podle medi�nu prvn�ch [utc_yawtime] krok�
dd = 1;
while r.utc(dd) < r.utc_yawtime
    dd = dd+1;
end
yaw1 = median(r.yaw(1:dd))


% utc_startup;
%% find entries nearest to utc_startup + x * 0.5sec
% entries_sum = (utc_end - utc_startup )*2
% entry_int(entries_sum) = 0.50; % how near the entry is to the ^^
% entry_index(entries_sum) = 1; % how near the entry is to the ^^
% % entry_xyth(entries_sum,1:4) = [0 0 0 utc_startup:0.5:utc_end];
% plot_these(1:steps-1) = 0;
% 
% for i=1:steps-1
%     entry_1dn_index = floor(r.utc(i) - utc_startup);
%     entry_1up_index = ceil(r.utc(i) - utc_startup);
%     
%     if entry_1dn_index > 0 
%     if entry_1dn_index < entries_sum
%         newint = abs( r.utc(i) - floor(r.utc(i)) );
%         if entry_int(entry_1dn_index) > newint
%             entry_int(entry_1dn_index) = newint;
%             entry_index(entry_1dn_index) = i;
%             plot_these( entry_1dn_index ) = 0;
%             plot_these(i) = 1;
% %             entry_xyth = [0 0 0 0 newint]
%         end
%     end
%     end
%     if entry_1up_index > 0 
%     if entry_1up_index < entries_sum
%         if entry_1up_index < entries_sum+1
%             newint = abs( ceil(r.utc(i)) - r.utc(i) ) ;
%             if entry_int(entry_1up_index) > newint
%                 entry_int(entry_1up_index) = newint;
%                 entry_index(entry_1up_index) = i;
%                 plot_these( entry_1up_index ) = 0;
%                 plot_these(i) = 1;
%             end
%         end
%     end
%     end
% end
%        utc_startup = 143224;
%        utc_end = 143413;


% entries_sum = (utc_end - utc_startup )*2;
% utc_points = [utc_startup:0.5:utc_end]';
% utc_points = utc_points + utc_offset;
% neares = dsearchn(r.utc(:), utc_points);
% 
% plot_these(steps-1) = 0;
% plot_these(neares) = 1;

% es_sum = (utc_end - utc_startup );
utc_points = [utc_startup:1:utc_end]';
utc_points = utc_points + utc_offset;
neares = dsearchn(r.utc(:), utc_points);

% utc_points - 143000
% utc_points - utc_startup
plot_these(steps-1) = 0;
plot_these(neares) = 1;

% es_sum = (utc_end - utc_startup );
utc_points = [utc_startup:1:utc_end]';
utc_points = utc_points + utc_offset + 0.5;
neares = dsearchn(r.utc(:), utc_points);

% r.utc(:)
% utc_points - 143000
% utc_points - utc_startup

plot_these(steps-1) = 0;
plot_these(neares) = 1;


% calculate and draw trajectory
plotted_steps = 1;
for i = 1: steps-1
    
r.x = r.e(i) - r.e(1);
r.y = r.n(i) - r.n(1);
% theta = -pi/2;


theta = +yaw1 - pi/2;
A = [cos(theta)  -sin(theta) ; sin(theta)  cos(theta)] * [r.x r.y]';
r.x = A(1);
r.y = A(2);
% r.y = -r.y;
r.th = r.yaw(i) + pi/2 -yaw1 - pi/2;
r.th = - r.th;

if(lastx ~= 0 && lasty ~= 0)
%     plot([lastx r.x+0.00001], [lasty r.y+0.00001], 'color',    chsv(i+1,:), 'LineWidth', 1);
    plot([lastx r.x+0.00001], [lasty r.y+0.00001], 'color',    chsv( steps-i,:), 'LineWidth', 1);
    plot(r.x, r.y, '*');
    if plot_these(i) == 1
% utc2  = r.utc(i) +  r.utc_offset
%      if mod(utc2 , r.plotAsec) && this_sec_plotted ~= utc2 
         
%          if r.robot_visible
             plot_robot(r);
%          end
%         this_sec_plotted = utc2 ;
        if plot_text && i < 500
            text(r.x, r.y,  [num2str(r.utc(i)),'+',num2str(utc_offset)]  , 'Color', g0.color1 );
%               text(r.x, r.y,  num2str(r.utc(i)), 'Color', g0.color1 );
        end
        utc2 = r.utc(i)+utc_offset;
        entry_xyth(1,plotted_steps,1:4) = [r.x r.y r.th utc2];

% rx_I = r.x;
% ry_I = r.y;
% rx_Iplus1 = r.e(i+1) - r.e(1);
% ry_Iplus1 = r.n(i+1) - r.n(1);
% theta = +yaw1 - pi/2;
% A_Iplus1 = [cos(theta)  -sin(theta) ; sin(theta)  cos(theta)] * [rx_Iplus1 ry_Iplus1]';
% rx_Iplus1 = A_Iplus1(1);
% ry_Iplus1 = A_Iplus1(2);
%     meanx = (rx_I + rx_Iplus1)/2;
%     meany = (ry_I + ry_Iplus1)/2;
%     mean_utc2 = (r.utc(i) + r.utc(i+1) ) /2 +utc_offset ;
%         entry_xyth(1,plotted_steps,1:4) = [meanx meany r.th mean_utc2];
        plotted_steps = plotted_steps +1;
     end
end
    lastx = r.x; lasty = r.y;
end

xyth = entry_xyth;


axis equal;
grid on;
xlabel ('x position [m]');
ylabel ('y position [m]');
% colorbar;
