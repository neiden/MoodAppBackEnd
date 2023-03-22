
--Populate posts
insert into POSTS (U_Id, Likes, Content, Comment_Date) values (5, 79, 'Aliquam quis turpis eget elit sodales scelerisque.', '2/19/2023');
insert into POSTS (U_Id, Likes, Content, Comment_Date) values (12, 9, 'Sed vel enim sit amet nunc viverra dapibus.', '1/10/2023');
insert into POSTS (U_Id, Likes, Content, Comment_Date) values (9, 31, 'Vestibulum ante ipsum primis in faucibus orci luctus et ultrices posuere cubilia Curae; Mauris viverra diam vitae quam.', '1/6/2023');
insert into POSTS (U_Id, Likes, Content, Comment_Date) values (3, 74, 'Morbi non quam nec dui luctus rutrum.', '9/7/2022');
insert into POSTS (U_Id, Likes, Content, Comment_Date) values (10, 35, 'Fusce posuere felis sed lacus.', '7/7/2022');
insert into POSTS (U_Id, Likes, Content, Comment_Date) values (1, 95, 'In congue.', '2/5/2023');
insert into POSTS (U_Id, Likes, Content, Comment_Date) values (5, 33, 'Vivamus tortor.', '7/15/2022');
insert into POSTS (U_Id, Likes, Content, Comment_Date) values (5, 25, 'Nam nulla.', '3/3/2023');
insert into POSTS (U_Id, Likes, Content, Comment_Date) values (2, 36, 'Integer pede justo, lacinia eget, tincidunt eget, tempus vel, pede.', '1/24/2023');

--Populte Comments
insert into COMMENTS (P_Id, Likes, Content, Comment_Date) values (7, 1, 'Sed vel enim sit amet nunc viverra dapibus.', '2023-03-10 08:33:15');
insert into COMMENTS (P_Id, Likes, Content, Comment_Date) values (16, 2, 'Maecenas pulvinar lobortis est.', '2022-12-05 00:24:00');
insert into COMMENTS (P_Id, Likes, Content, Comment_Date) values (26, 1, 'Vivamus tortor.', '2022-08-25 22:18:15');
insert into COMMENTS (P_Id, Likes, Content, Comment_Date) values (7, 1, 'Mauris enim leo, rhoncus sed, vestibulum sit amet, cursus id, turpis.', '2022-11-27 13:05:23');
insert into COMMENTS (P_Id, Likes, Content, Comment_Date) values (1, 3, 'In eleifend quam a odio.', '2022-05-02 05:54:05');
insert into COMMENTS (P_Id, Likes, Content, Comment_Date) values (11, 0, 'Integer a nibh.', '2022-03-21 16:38:56');
insert into COMMENTS (P_Id, Likes, Content, Comment_Date) values (7, 0, 'Proin eu mi.', '2023-02-02 01:55:15');
insert into COMMENTS (P_Id, Likes, Content, Comment_Date) values (19, 0, 'Nulla mollis molestie lorem.', '2022-06-07 07:37:39');
insert into COMMENTS (P_Id, Likes, Content, Comment_Date) values (21, 0, 'Maecenas tristique, est et tempus semper, est quam pharetra magna, ac consequat metus sapien ut nunc.', '2022-12-24 11:17:18');
insert into COMMENTS (P_Id, Likes, Content, Comment_Date) values (11, 1, 'Etiam faucibus cursus urna.', '2022-09-13 13:11:15');
insert into COMMENTS (P_Id, Likes, Content, Comment_Date) values (11, 3, 'Vestibulum ac est lacinia nisi venenatis tristique.', '2023-02-14 06:29:03');
insert into COMMENTS (P_Id, Likes, Content, Comment_Date) values (21, 1, 'Praesent blandit lacinia erat.', '2023-01-03 02:41:32');

--Populate Friends
insert into FRIENDS (Source_Id, Target_Id) values (5, 3);
insert into FRIENDS (Source_Id, Target_Id) values (1, 6);
insert into FRIENDS (Source_Id, Target_Id) values (7, 3);
insert into FRIENDS (Source_Id, Target_Id) values (2, 9);
insert into FRIENDS (Source_Id, Target_Id) values (8, 3);
insert into FRIENDS (Source_Id, Target_Id) values (6, 3);
insert into FRIENDS (Source_Id, Target_Id) values (1, 7);
insert into FRIENDS (Source_Id, Target_Id) values (7, 6);
insert into FRIENDS (Source_Id, Target_Id) values (1, 5);
insert into FRIENDS (Source_Id, Target_Id) values (2, 6);

--Populate Mood
insert into MOODS (U_id, mDate, Category, Score) values (8, '2023-01-12 20:50:16', 'happy', 0.36);
insert into MOODS (U_id, mDate, Category, Score) values (6, '2022-07-27 15:03:43', 'blue', -0.1);
insert into MOODS (U_id, mDate, Category, Score) values (9, '2022-09-12 01:39:07', 'excited', 0.76);
insert into MOODS (U_id, mDate, Category, Score) values (2, '2022-11-01 05:24:57', 'neutral', 0.25);
insert into MOODS (U_id, mDate, Category, Score) values (10, '2022-04-17 15:25:57', 'stressed', -0.32);
insert into MOODS (U_id, mDate, Category, Score) values (8, '2022-07-14 08:24:50', 'happy', 0.7);
insert into MOODS (U_id, mDate, Category, Score) values (3, '2022-08-09 00:43:42', 'doubtful', -0.12);
insert into MOODS (U_id, mDate, Category, Score) values (4, '2022-04-03 21:30:26', 'neutral', -0.05);
insert into MOODS (U_id, mDate, Category, Score) values (7, '2022-12-02 08:20:20', 'very happy', 0.85);
insert into MOODS (U_id, mDate, Category, Score) values (7, '2023-02-27 06:39:52', 'extremely happy', 0.89);

