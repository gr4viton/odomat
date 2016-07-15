function [meas,utc] = parse_meas(cislo_mereni)
% clc; clear; 
% filename = 'C:\ODO\11\try.txt';
filename = strcat( 'D:\EDUC\bak_bakalarka\mereni\backupSt\_st\01 – kopie (' , num2str(cislo_mereni), ')\odolog_parsed.txt');


fileID = fopen(filename);
% formatSpec = '%c%c%s%c%i%c%i%c%c%c%c%i%c%i%c%
formatSpec = '%d %f %u %d %d';
% C = textscan(fileID,'%c%u%c%u%c%s',1);
C = textscan(fileID,formatSpec,10000);
fclose(fileID);

% disp(['utc',utc])
% utc
% ss = cell2mat(C(4))
meas = [cell2mat(C(4)) -cell2mat(C(5))];
aa = size(meas,1);

utc = cell2mat(C(2));
% utc = double(utc) - 143011
utc = double(utc)

itersum = 0;
% meas2 = meas;
iter2 = cell2mat(C(3));
for i=2:(aa -1)
   if iter2(i) >= 2
       disp(['iter2=',iter2]);
%         meas2 (i,1) = ( meas(i-1,1)+meas(i+1,1) )/2 + meas(i,1);
%         meas2 (i,2) = ( meas(i-1,2)+meas(i+1,2) )/2 + meas(i,2);
%         meas2 (i,1) = ( meas(i-1,1)+meas(i+1,1) )/2;
%         meas2 (i,2) = ( meas(i-1,2)+meas(i+1,2) )/2;
%         meas2 (i,1) = 0;
%         meas2 (i,2) = 0;  
        itersum= itersum+1;
   end
end
disp(['itersum',itersum]);
% meas - meas2 ;

% meas = [meas2(:,1) meas2(:,2)];
 
% disp(C(1))
% disp(C)
%  meas = repmat([1600 1600], 101,1);