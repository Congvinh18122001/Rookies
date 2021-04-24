import axios from 'axios';


// function getApiUrl(api: string) {
//     return api.indexOf('http') >= 0
//         ? api
//         : AppConfig.baseUrl + api;
// }

// function getHeader(token?: string) {
//     let headers = {
//         'Content-Type': 'application/json',
//         'Authorization': `Bearer ${token}` || ''
//     };

//     return headers;
// }

// // for multiple requests
// let isRefreshing = false;
// let failedQueue: any[] = [];

// const processQueue = (error: any, token = null) => {
//     failedQueue.forEach(prom => {
//         if (error) {
//             prom.reject(error);
//         } else {
//             prom.resolve(token);
//         }
//     })

//     failedQueue = [];
// }

// const getAuth = () => {
//     const token = localStorage.getItem('token');
//     return 'Bearer ' + token;
// }

// axios.interceptors.response.use((response) => {
//     return response;
// }, (error) => {

//     const originalRequest = error.config;

//     if (error.response.status === 401 && !originalRequest._retry) {

//         if (isRefreshing) {
//             return new Promise(function (resolve, reject) {
//                 failedQueue.push({ resolve, reject })
//             }).then(token => {
//                 originalRequest.headers['Authorization'] = 'Bearer ' + token;
//                 return axios(originalRequest);
//             }).catch(err => {
//                 return Promise.reject(err);
//             })
//         }

//         if(originalRequest.headers.Authorization !== getAuth()) { 
//             originalRequest.headers['Authorization'] = getAuth(); 
//             return Promise.resolve(axios(originalRequest)); 
//         }
        
//         originalRequest._retry = true;
//         isRefreshing = true;

//         const refreshToken = localStorage.getItem('refreshToken');
//         const email = localStorage.getItem('email');
//         return new Promise(function (resolve, reject) {
//             postData('user/refreshToken', {
//                 'refreshToken': refreshToken,
//                 'email': email
//             })
//                 .then((data) => {
//                     localStorage.setItem('refreshToken', data.refreshToken);
//                     localStorage.setItem('token', data.token);
//                     axios.defaults.headers.common['Authorization'] = 'Bearer ' + data.token;
//                     originalRequest.headers['Authorization'] = 'Bearer ' + data.token;
//                     processQueue(null, data.token);
//                     resolve(axios(originalRequest));
//                 })
//                 .catch((err) => {
//                     processQueue(err, null);
//                     reject(err);
//                 })
//                 .then(() => { isRefreshing = false })
//         })
//     }

//     return Promise.reject(error);
// });

export async function getData(api: string, token?: string) {
    // var apiUrl = getApiUrl(api);
    // var init: AxiosRequestConfig = {
    //     headers: getHeader(token)
    // };
    const response = await axios.get(api);
    return response.data;

}

export async function postData(api: string, data: any, token?: string) {
    // var apiUrl = getApiUrl(api);
    // var init: AxiosRequestConfig = {
    //     headers: getHeader(token),
    // };
    const response = await axios.post(api, data);
    return response.data;

}

export async function putData(api: string, data: any, token?: string) {
    // var apiUrl = getApiUrl(api);
    // var init: AxiosRequestConfig = {
    //     headers: getHeader(token),
    // };
    const response = await axios.put(api, data);
    return response.data;

}

export async function deleteData(api: string, token?: string, data?: any) {
    // var apiUrl = getApiUrl(api);
    // var init: AxiosRequestConfig = {
    //     headers: getHeader(token),
    //     data
    // };
    const response = await axios.delete(api);
    return response.data;

}
axios.interceptors.request.use(function (config) {
    // const a = localStorage.getItem("userInfor");
    const token = localStorage.getItem("token");

    if (!token) {
        return config;
    }
    // const  user = a&&JSON.parse(a);
    // config.headers.Username =  user.username;
    // config.headers.UserID =  user.id;
    config.headers.Authorization = token;
    return config;
  });