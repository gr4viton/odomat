function [g] = parse_gps(g,filename)

% filename = 'C:\ODO\11\try.txt';
% filename = 'D:\EDUC\bak_bakalarka\mereni\backupUt\11\gpslog_parsed_2.txt';
fileID = fopen(filename);
% formatSpec = '%c%c%s%c%i%c%i%c%c%c%c%i%c%i%c%
formatSpec = '%f %f %f %f %f %f';
% C = textscan(fileID,'%c%u%c%u%c%s',1);
C = textscan(fileID,formatSpec,10000);
% disp(C)
fclose('all');
% hhmmss = C(1);

% ss = cell2mat(C(4))
g.utc = cell2mat(C(1));
g.eM = cell2mat(C(2)) ;
g.nM = cell2mat(C(3)) ;
g.u = cell2mat(C(4)) ;
g.yaw = cell2mat(C(5));
g.tilt = cell2mat(C(6));
% g.tilt
g.tilt = deg2rad (g.tilt);
g.yaw = deg2rad (g.yaw);


% aa = size(meas,1);
xx = g.H .* cos(g.tilt) ;
deltay =  g.H * sin(g.tilt);
g.L = xx - (g.u + g.K - deltay) .* tan(g.tilt);

% disp(g.L);
% disp(g.yaw);

g.e = g.eM - g.L.*sin(g.yaw);
g.n = g.nM - g.L.*cos(g.yaw);
% g.e = g.eM;
% g.n = g.nM;
% disp(C(1))
% disp(C)
%  meas = repmat([1600 1600], 101,1);