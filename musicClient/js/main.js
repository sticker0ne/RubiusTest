Vue.component('modal', {
    template: '#modal-template'
})

// start app
new Vue({
    el: '#app',
    data: {
        showModal: false,
        inputName: '',
        userId: '',
        userName: '',
        helloString: 'Похоже, вы у нас впервые, для того, чтобы воспользоваться всеми функциями, пожалуйста введите свое имя',
        headerString: 'Здравствуйте',
        musicians: [],
        favorite: []
    },

    methods: {
        addToListened(trackId, albId, musId) {
            event.stopPropagation();
            event.preventDefault();
            var musIndex = this.musicians.findIndex(value => value.id == musId);
            var albIndex = this.musicians[musIndex].albums.findIndex(value => value.id == albId);
            var trIndex = this.musicians[musIndex].albums[albIndex].tracks.findIndex(value => value.id == trackId);
            var string = "http://musicservice.tom.ru/api/AddTrackToListened?trackId=" + trackId + "&userId="
                + this.userId;
            axios.get(string)
                .then(response => {
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].likeStatus = response.data.likeStatus;
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].id = response.data.id;
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].name = response.data.name;
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].duration = response.data.duration;
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].rating = response.data.rating;
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].isListened = response.data.isListened;
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].isFavorite = response.data.isFavorite;
                    this.updateFavorite();
                });

        },
        setLikeStatus(trackId, albId, musId, status) {
            event.preventDefault();
            event.stopPropagation();
            var musIndex = this.musicians.findIndex(value => value.id == musId);
            var albIndex = this.musicians[musIndex].albums.findIndex(value => value.id == albId);
            var trIndex = this.musicians[musIndex].albums[albIndex].tracks.findIndex(value => value.id == trackId);
            var string = "http://musicservice.tom.ru/api/setLikeStatus?trackId=" + trackId + "&userId=" +
                this.userId + "&status=" + status;
            axios.get(string)
                .then(response => {
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].likeStatus = response.data.likeStatus;
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].id = response.data.id;
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].name = response.data.name;
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].duration = response.data.duration;
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].rating = response.data.rating;
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].isListened = response.data.isListened;
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].isFavorite = response.data.isFavorite;
                    this.updateFavorite();
                });

        },
        removeFromFavorite(trackId, albId, musId) {
            event.stopPropagation();
            event.preventDefault();
            var musIndex = this.musicians.findIndex(value => value.id == musId);
            var albIndex = this.musicians[musIndex].albums.findIndex(value => value.id == albId);
            var trIndex = this.musicians[musIndex].albums[albIndex].tracks.findIndex(value => value.id == trackId);
            var string = "http://musicservice.tom.ru/api/removeTrackfromFavorite?trackId=" + trackId + "&userId="
                + this.userId;
            axios.get(string)
                .then(response => {
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].likeStatus = response.data.likeStatus;
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].id = response.data.id;
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].name = response.data.name;
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].duration = response.data.duration;
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].rating = response.data.rating;
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].isListened = response.data.isListened;
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].isFavorite = response.data.isFavorite;
                    this.updateFavorite();
                });

        },
        addToFavorite(trackId, albId, musId) {
            event.stopPropagation();
            event.preventDefault();
            var musIndex = this.musicians.findIndex(value => value.id == musId);
            var albIndex = this.musicians[musIndex].albums.findIndex(value => value.id == albId);
            var trIndex = this.musicians[musIndex].albums[albIndex].tracks.findIndex(value => value.id == trackId);
            var string = "http://musicservice.tom.ru/api/AddTrackToFavorite?trackId=" + trackId + "&userId="
                + this.userId;
            axios.get(string)
                .then(response => {
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].likeStatus = response.data.likeStatus;
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].id = response.data.id;
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].name = response.data.name;
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].duration = response.data.duration;
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].rating = response.data.rating;
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].isListened = response.data.isListened;
                    this.musicians[musIndex].albums[albIndex].tracks[trIndex].isFavorite = response.data.isFavorite;
                    this.updateFavorite();
                });

        },
        stop() {
            event.stopPropagation();
        },
        fillTracks(albId, musId) {
            event.stopPropagation();
            var musIndex = this.musicians.findIndex(value => value.id == musId);
            var albIndex = this.musicians[musIndex].albums.findIndex(value => value.id == albId);
            if (!this.musicians[musIndex].albums[albIndex].isActive) {
                this.musicians[musIndex].albums[albIndex].tracks = [];
                axios.get("http://musicservice.tom.ru/api/getTracks?albumId=" + albId + "&userId=" + this.userId)
                    .then(response => {
                        response.data.tracks.forEach(function (el) {
                            this.musicians[musIndex].albums[albIndex].tracks.push({
                                id: el.id,
                                name: el.name,
                                duration: el.duration,
                                likeStatus: el.likeStatus,
                                rating: el.rating,
                                isListened: el.isListened,
                                isFavorite: el.isFavorite

                            })
                        }.bind(this));
                        console.log(response);
                    });
                this.musicians[musIndex].albums[albIndex].isActive = true;
            }
            else {
                this.musicians[musIndex].albums[albIndex].isActive = false;
            }

        },
        fillAlbums(musId) {
            if (event.target.toString() == 'div.album')
                return;
            var index = this.musicians.findIndex(value => value.id == musId);
            if (!this.musicians[index].isActive) {
                this.musicians[index].albums = [];
                axios.get("http://musicservice.tom.ru/api/getAlbums?musicianId=" + musId)
                    .then(response => {
                        response.data.albums.forEach(function (el) {
                            this.musicians[index].albums.push({
                                id: el.id,
                                name: el.name,
                                releaseYear: el.releaseYear,
                                isActive: false,
                                tracks: []
                            })
                        }.bind(this));
                        console.log(response);
                    });
                this.musicians[index].isActive = true;
            }
            else {
                this.musicians[index].isActive = false;
            }
        },
        updateFavorite() {
            this.favorite = [];
            axios.get("http://musicservice.tom.ru/api/getFavoriteTracks?&userId=" + this.userId)
                .then(response => {
                    response.data.tracks.forEach(function (el) {
                        this.favorite.push({
                            id: el.id,
                            name: el.name,
                            duration: el.duration,
                            likeStatus: el.likeStatus,
                            rating: el.rating,
                            isListened: el.isListened,
                            isFavorite: el.isFavorite

                        })
                    }.bind(this));
                    console.log(response);
                });
        },
        fillMusicians() {
            axios.get("http://musicservice.tom.ru/api/getMusicians")
                .then(response => {
                    response.data.musicians.forEach(function (el) {
                        this.musicians.push({
                            id: el.id,
                            name: el.name,
                            careerStartYear: el.careerStartYear,
                            age: el.age,
                            isActive: false,
                            albums: []
                        })
                    }.bind(this));
                    console.log(response);
                    if (this.favorite.length == 0)
                        this.updateFavorite();
                });
        },
        close() {
            if (this.inputName == '') {
                this.helloString = 'Мы настоятельно рекомендуем ввести имя';
                return;
            }
            this.helloString = "Ожидайте..."
            axios.get("http://musicservice.tom.ru/api/createUser?name=" + this.inputName)
                .then(response => {
                    this.userId = response.data.id;
                    this.userName = response.data.firstName;
                    localStorage.setItem('userName', response.data.firstName);
                    localStorage.setItem('userId', response.data.id);
                    console.log(response);
                    this.showModal = false;
                    this.fillMusicians();
                });

        },
        clearData() {
            localStorage.clear();
            location.reload();
        }

    },
    mounted: function () {
        if (!localStorage.getItem('userId') || !localStorage.getItem('userName')) {
            this.showModal = true;
        }
        else {
            this.userId = localStorage.getItem('userId');
            this.userName = localStorage.getItem('userName');
            this.fillMusicians();
        }
    },
})

