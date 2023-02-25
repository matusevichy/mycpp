export function MusicGroup(props){
    return (
        <div className="music-group">
            <h2>{props.group.name}</h2>
            <div className="member-list">
                <h3>Members:</h3>
                {props.group.members.map((member, i) => <i>{member}, </i>) }
            </div>
            <div className="album-list">
                <h3>Albums:</h3>
                {props.group.albums.map((album, i) => <i>{album}, </i>) }
            </div>
            <div className="cover-list">
                <h3>Covers:</h3>
                {props.group.covers.map((cover, i) => <img src={cover} />) }
            </div>
        </div>
    )
}