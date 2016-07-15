function [i_rob, rob] = ground_truth(rob0)

%% ground true
i_rob = 6;
rob = repmat(rob0,1,i_rob);
i=1;
% rand11 = (rand( siz ,2) - 0.5) * 2; %from -1 to +1
% dlmwrite('rand11.txt', rand11, 'precision', '%.6f', 'newline', 'pc')
% rand11 = dlmread('rand11.txt');


rob(i).plot_period = 25;
rob(i).variance_visible = 0;
rob(i).color1 = [0.6 0.6 0.6];
rob(i).robline = '--';
rob(i).calc_prob = 0;

% rob(1).meas = [astr2; astr2; tleftL8s ; astr2; tleftL8s; astr2;astr2; astr2;astr2; astr2;astr2;];
% % rob(i).meas = [astr2; cleft; tleft8s ; rleft; rleft;  astr2; tleft8s; cleft;astr2; astr2;astr2; cleft;astr2;];
% % rob(1).meas = repmat(cleft,20,1);
rob(1).meas = [str;str;str;str;str;tleft8s;str;str;str;str;str;tleft8s;str;str;str;];

i=i+1;
rob(i).plot_period = rob(i-1).plot_period;
rob(i).x = rob(i-1).x; rob(i).y = rob(i-1).y; rob(i).th = rob(i-1).th;
siz = size(rob(i-1).meas,1);
rand11 = (rand( siz ,2) - 0.5) * 2; %from -1 to +1
% dlmwrite('rand11.txt', rand11, 'precision', '%.6f', 'newline', 'pc')
% rand11 = rand11 *10;
%         + rnd nums to see how the probability grows with error.. 

rob(i).meas = rob(i-1).meas;
% rob(i).meas = rob(i-1).meas + rand11 .* repmat([rob(i).eL  rob(i).eR], siz,1);
rob(i).calc_eqn = 1;


%% second ground truth
i=i+1;
xx=+3;
yy=-3;
rob(i) = rob(i-2);
rob(i).y = rob(i).y +yy;
rob(i).x = rob(i).x +xx;

i=i+1;
rob(i) = rob(i-2);
rob(i).y = rob(i).y +yy;
rob(i).x = rob(i).x +xx;
rob(i).calc_eqn = 0;

%% third ground truth
i=i+1;
rob(i) = rob(i-2);
rob(i).y = rob(i).y +yy;
rob(i).x = rob(i).x +xx;

i=i+1;
rob(i) = rob(i-2);
rob(i).y = rob(i).y +yy;
rob(i).x = rob(i).x +xx;
rob(i).meas = rob(i-1).meas + rand11 .* repmat([rob(i).eL  rob(i).eR], siz,1);
rob(i).calc_eqn = 3;
