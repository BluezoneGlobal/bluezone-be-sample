/*
 * @Project Bluezone
 * @Author Bluezone Global (contact@bluezone.ai)
 * @Createdate 26/04/2020, 16:36 
 *
 * This file is part of Bluezone (https://bluezone.ai)
 *
 * This program is free software: you can redistribute it and/or modify
 * it under the terms of the GNU General Public License as published by
 * the Free Software Foundation, either version 3 of the License, or
 * (at your option) any later version.
 *
 * This program is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU General Public License for more details.
 *
 * You should have received a copy of the GNU General Public License
 * along with this program. If not, see <http://www.gnu.org/licenses/>.
 */


const express = require('express');
const router = express.Router();
var admin = require('firebase-admin');
var serviceAccount = require('./serviceAccountKey.json');

admin.initializeApp({
  credential: admin.credential.cert(serviceAccount),
  databaseURL: 'https://covid19-1ffcf.firebaseio.com',
});

let tenTopic = 'test3';

router.post('/sendTopic', (req, res, next) => {
  var message = {
    notification: {
      title: 'Phát hiện F0 có BluezoneID: ' + req.body.usercode,
      body: 'Bạn vui lòng kiểm tra lịch sử tiếp xúc',
    },
    data: {
      NotifyCode: '1',
      UserCodeFind: req.body.usercode,
      MacBluetooth: '',
    },
    topic: tenTopic,
  };
  admin
    .messaging()
    .send(message)
    .then((response) => {
      res.status(200).json(response);
    })
    .catch((error) => {
      res.status(500).json(error);
    });
});

router.post('/sendFcm', (req, res, next) => {
  let fcmid = req.body.fcmid;
  var message = {
    notification: {
      title: 'Yêu cầu gửi lịch sử tiếp xúc',
      body: 'Yêu cầu gửi lịch sử tiếp xúc',
    },
    data: {
      NotifyCode: '2',
    },
    token: fcmid,
  };
  admin
    .messaging()
    .send(message)
    .then((response) => {
      res.status(200).json(response);
    })
    .catch((error) => {
      res.status(500).json(error);
    });
});

module.exports = router;
